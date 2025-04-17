using Hope.Application.Admin.DTOs;
using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Hope.Application.MissingPerson.DTOs;
using Hope.Application.Users.DTOs;
using Hope.Domain.Entities;
using Hope.Domain.Enums;
using Hope.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.Infrastructure.Services
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AdminService> _logger;

        public AdminService(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<AdminService> logger)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        #region User Management

        public async Task<Result<int>> GetUserCountAsync()
        {
            try
            {
                var count = await _userManager.Users.CountAsync();
                return Result<int>.Success(count);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting user count");
                return Result<int>.Failure("Error getting user count: " + ex.Message);
            }
        }

        public async Task<Result<List<WeeklyCountDto>>> GetNumberOfNewUserPerWeekAsync()
        {
            try
            {
                // Get users created in the last 10 weeks
                var tenWeeksAgo = DateTime.UtcNow.AddDays(-70);
                var users = await _userManager.Users
                    .Where(u => u.CreatedAt >= tenWeeksAgo)
                    .ToListAsync();

                // Group by week
                var weeklyCounts = users
                    .GroupBy(u => new { Year = u.CreatedAt.Year, Week = GetIso8601WeekOfYear(u.CreatedAt) })
                    .Select(g => new WeeklyCountDto
                    {
                        WeekStartDate = GetFirstDayOfWeek(g.Key.Year, g.Key.Week),
                        Count = g.Count()
                    })
                    .OrderBy(w => w.WeekStartDate)
                    .ToList();

                return Result<List<WeeklyCountDto>>.Success(weeklyCounts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting new users per week");
                return Result<List<WeeklyCountDto>>.Failure("Error getting new users per week: " + ex.Message);
            }
        }

        public async Task<Result<List<UserDto>>> GetAllUsersAsync()
        {
            try
            {
                var users = await _userManager.Users.ToListAsync();
                var userDtos = new List<UserDto>();

                foreach (var user in users)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    userDtos.Add(new UserDto
                    {
                        Id = user.Id,
                        UserName = user.UserName,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        CreatedAt = user.CreatedAt,
                        Roles = roles.ToList()
                    });
                }

                return Result<List<UserDto>>.Success(userDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all users");
                return Result<List<UserDto>>.Failure("Error getting all users: " + ex.Message);
            }
        }

        public async Task<Result<bool>> DeleteUserAsync(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return Result<bool>.Failure("User not found");
                }

                // Check if user is SuperAdmin
                var isSuperAdmin = await _userManager.IsInRoleAsync(user, "SuperAdmin");
                if (isSuperAdmin)
                {
                    return Result<bool>.Failure("Cannot delete a SuperAdmin user");
                }

                var result = await _userManager.DeleteAsync(user);
                if (!result.Succeeded)
                {
                    return Result<bool>.Failure("Failed to delete user: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                }

                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting user {UserId}", userId);
                return Result<bool>.Failure("Error deleting user: " + ex.Message);
            }
        }

        public async Task<Result<string>> AdminRegisterAsync(string userName, string email, string password, bool isAdmin)
        {
            try
            {
                // Check if user already exists
                var existingUser = await _userManager.FindByEmailAsync(email);
                if (existingUser != null)
                {
                    return Result<string>.Failure("User with this email already exists");
                }

                // Create new user
                var user = new ApplicationUser
                {
                    UserName = userName,
                    Email = email,
                    CreatedAt = DateTime.UtcNow
                };

                var result = await _userManager.CreateAsync(user, password);
                if (!result.Succeeded)
                {
                    return Result<string>.Failure("Failed to create user: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                }

                // Assign role
                string role = isAdmin ? "Admin" : "User";
                
                // Ensure role exists
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
                
                await _userManager.AddToRoleAsync(user, role);

                return Result<string>.Success(user.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error registering admin user");
                return Result<string>.Failure("Error registering admin user: " + ex.Message);
            }
        }

        public async Task<Result<List<UserDto>>> GetAllAdminsAsync()
        {
            try
            {
                var adminRole = await _roleManager.FindByNameAsync("Admin");
                if (adminRole == null)
                {
                    return Result<List<UserDto>>.Success(new List<UserDto>());
                }

                var adminUsers = await _userManager.GetUsersInRoleAsync("Admin");
                var superAdminUsers = await _userManager.GetUsersInRoleAsync("SuperAdmin");
                
                var allAdminUsers = adminUsers.Union(superAdminUsers).ToList();
                
                var userDtos = new List<UserDto>();
                foreach (var user in allAdminUsers)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    userDtos.Add(new UserDto
                    {
                        Id = user.Id,
                        UserName = user.UserName,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        CreatedAt = user.CreatedAt,
                        Roles = roles.ToList()
                    });
                }

                return Result<List<UserDto>>.Success(userDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all admins");
                return Result<List<UserDto>>.Failure("Error getting all admins: " + ex.Message);
            }
        }

        public async Task<Result<int>> GetAdminsCountAsync()
        {
            try
            {
                var adminRole = await _roleManager.FindByNameAsync("Admin");
                if (adminRole == null)
                {
                    return Result<int>.Success(0);
                }

                var adminUsers = await _userManager.GetUsersInRoleAsync("Admin");
                var superAdminUsers = await _userManager.GetUsersInRoleAsync("SuperAdmin");
                
                var totalCount = adminUsers.Count + superAdminUsers.Count;
                
                return Result<int>.Success(totalCount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting admins count");
                return Result<int>.Failure("Error getting admins count: " + ex.Message);
            }
        }

        #endregion

        #region Report Management

        public async Task<Result<int>> GetPostsCountAsync()
        {
            try
            {
                var count = await _context.Reports.CountAsync(r => !r.IsDeleted);
                return Result<int>.Success(count);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting posts count");
                return Result<int>.Failure("Error getting posts count: " + ex.Message);
            }
        }

        public async Task<Result<int>> GetDeletedPostsCountAsync()
        {
            try
            {
                var count = await _context.Reports.CountAsync(r => r.IsDeleted);
                return Result<int>.Success(count);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting deleted posts count");
                return Result<int>.Failure("Error getting deleted posts count: " + ex.Message);
            }
        }

        public async Task<Result<List<WeeklyCountDto>>> GetNumberOfNewPostsPerWeekAsync()
        {
            try
            {
                // Get reports created in the last 10 weeks
                var tenWeeksAgo = DateTime.UtcNow.AddDays(-70);
                var reports = await _context.Reports
                    .Where(r => r.ReportTime >= tenWeeksAgo)
                    .ToListAsync();

                // Group by week
                var weeklyCounts = reports
                    .GroupBy(r => new { Year = r.ReportTime.Year, Week = GetIso8601WeekOfYear(r.ReportTime) })
                    .Select(g => new WeeklyCountDto
                    {
                        WeekStartDate = GetFirstDayOfWeek(g.Key.Year, g.Key.Week),
                        Count = g.Count()
                    })
                    .OrderBy(w => w.WeekStartDate)
                    .ToList();

                return Result<List<WeeklyCountDto>>.Success(weeklyCounts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting new posts per week");
                return Result<List<WeeklyCountDto>>.Failure("Error getting new posts per week: " + ex.Message);
            }
        }

        public async Task<Result<ReportDto>> GetPostByIdAsync(Guid reportId)
        {
            try
            {
                var report = await _context.Reports
                    .Include(r => r.Center)
                    .Include(r => r.Government)
                    .Include(r => r.User)
                    .Include(r => r.MissingPerson)
                        .ThenInclude(mp => mp.Images)
                    .Include(r => r.MissingThing)
                        .ThenInclude(mt => mt.Images)
                    .FirstOrDefaultAsync(r => r.Id == reportId);

                if (report == null)
                {
                    return Result<ReportDto>.Failure("Report not found");
                }

                return Result<ReportDto>.Success(ReportDto.FromEntity(report));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting post by ID {ReportId}", reportId);
                return Result<ReportDto>.Failure("Error getting post by ID: " + ex.Message);
            }
        }

        public async Task<Result<bool>> UnHideReportAsync(Guid reportId)
        {
            try
            {
                var report = await _context.Reports.FindAsync(reportId);
                if (report == null)
                {
                    return Result<bool>.Failure("Report not found");
                }

                report.IsHidden = false;
                await _context.SaveChangesAsync();
                
                _logger.LogInformation("Report with ID {ReportId} has been unhidden", reportId);
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error unhiding report {ReportId}", reportId);
                return Result<bool>.Failure("Error unhiding report: " + ex.Message);
            }
        }

        public async Task<Result<IEnumerable<ReportDto>>> GetArchivedReportsAsync()
        {
            try
            {
                var query = _context.Reports
                    .Include(r => r.Center)
                    .Include(r => r.Government)
                    .Include(r => r.User)
                    .Include(r => r.MissingPerson)
                        .ThenInclude(mp => mp.Images)
                    .Include(r => r.MissingThing)
                        .ThenInclude(mt => mt.Images)
                    .Where(r => r.IsDeleted)
                    .AsQueryable();

                var reports = await query.ToListAsync();
                return Result<IEnumerable<ReportDto>>.Success(reports.Select(x => ReportDto.FromEntity(x)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving archived reports");
                return Result<IEnumerable<ReportDto>>.Failure("Error retrieving archived reports: " + ex.Message);
            }
        }

        public async Task<Result<IEnumerable<ReportDto>>> GetAllPostsAsync()
        {
            try
            {
                var query = _context.Reports
                    .Include(r => r.Center)
                    .Include(r => r.Government)
                    .Include(r => r.User)
                    .Include(r => r.MissingPerson)
                        .ThenInclude(mp => mp.Images)
                    .Include(r => r.MissingThing)
                        .ThenInclude(mt => mt.Images)
                    .AsQueryable();

                var reports = await query.ToListAsync();
                return Result<IEnumerable<ReportDto>>.Success(reports.Select(x => ReportDto.FromEntity(x)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all posts");
                return Result<IEnumerable<ReportDto>>.Failure("Error retrieving all posts: " + ex.Message);
            }
        }

        public async Task<Result<IEnumerable<ReportDto>>> GetPostThingsAsync()
        {
            try
            {
                var query = _context.Reports
                    .Include(r => r.Center)
                    .Include(r => r.Government)
                    .Include(r => r.User)
                    .Include(r => r.MissingThing)
                        .ThenInclude(mt => mt.Images)
                    .Where(r => r.ReportSubjectType == ReportSubjectType.Thing && !r.IsDeleted)
                    .AsQueryable();

                var reports = await query.ToListAsync();
                return Result<IEnumerable<ReportDto>>.Success(reports.Select(x => ReportDto.FromEntity(x)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving thing posts");
                return Result<IEnumerable<ReportDto>>.Failure("Error retrieving thing posts: " + ex.Message);
            }
        }

        #endregion

        #region Helper Methods

        private static int GetIso8601WeekOfYear(DateTime date)
        {
            // Return the ISO 8601 week of year
            var day = (int)System.Globalization.CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(date);
            if (day == 0) day = 7; // Sunday is 7, not 0

            // Add days to get to Thursday (ISO 8601 week is based on Thursday)
            date = date.AddDays(4 - day);

            // Get the first day of the year
            var startOfYear = new DateTime(date.Year, 1, 1);

            // Calculate the number of days from the start of the year
            var days = (date - startOfYear).Days;

            // Return the week number
            return (days / 7) + 1;
        }

        private static DateTime GetFirstDayOfWeek(int year, int weekOfYear)
        {
            // Get the first day of the year
            var jan1 = new DateTime(year, 1, 1);
            
            // Get the day of the week for January 1
            var daysOffset = (int)System.Globalization.CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(jan1);
            
            // Get the first Thursday of the year (ISO 8601 week starts with Monday)
            var firstThursday = jan1.AddDays((daysOffset <= 4) ? (4 - daysOffset) : (11 - daysOffset));
            
            // Get the week number of the first Thursday
            var firstWeek = GetIso8601WeekOfYear(firstThursday);
            
            // Calculate the start date of the requested week
            var result = firstThursday.AddDays((weekOfYear - firstWeek) * 7 - 3);
            
            return result;
        }

        #endregion
    }
}