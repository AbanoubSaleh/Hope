using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Hope.Application.LookUps.Dtos;
using Hope.Application.MissingPerson.DTOs;
using Hope.Application.Users.DTOs;
using Hope.Domain.Entities;
using Hope.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IFileStorageService _fileService;
        private readonly ILogger<UserService> _logger;

        public UserService(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            IFileStorageService fileService,
            ILogger<UserService> logger)
        {
            _context = context;
            _userManager = userManager;
            _fileService = fileService;
            _logger = logger;
        }

        public async Task<Result<UserProfileDto>> GetUserProfileAsync(string userId, bool includeHiddenReports)
        {
            try
            {
                var user = await _context.Users.Include(user => user.Government).FirstOrDefaultAsync(x=>x.Id == userId);
                if (user == null || user.IsDeleted)
                {
                    return Result<UserProfileDto>.Failure("User not found");
                }

                // Get user's reports
                var reportsQuery = _context.Reports
                    .Include(r => r.MissingPerson)
                    .ThenInclude(r => r.Images)
                    .Include(r => r.MissingThing)
                    .ThenInclude(r => r.Images)
                    .Include(r => r.Center)
                    .Include(r => r.Government)
                    .Where(r => r.UserId == userId && !r.IsDeleted);

                // If not viewing own profile, filter out hidden reports
                if (!includeHiddenReports)
                {
                    reportsQuery = reportsQuery.Where(r => !r.IsHidden);
                }

                var reports = await reportsQuery.ToListAsync();

                // Map reports to DTOs
                var reportDtos = reports.Select(r => ReportDto.FromEntity(r)).ToList();

                // Create user profile DTO
                var userProfile = new UserProfileDto
                {
                    Id = user.Id,
                    UserName = user.UserName!,
                    Email = user.Email!,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    ProfileImageUrl = user.ProfileImageUrl,
                    CreatedAt = user.CreatedAt,
                    Government = GovernmentDto.FromEntity(user.Government!),
                    Reports = reportDtos
                };

                return Result<UserProfileDto>.Success(userProfile);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting user profile for user {UserId}", userId);
                return Result<UserProfileDto>.Failure("Error getting user profile: " + ex.Message);
            }
        }

        public async Task<Result<bool>> UpdateUserDataAsync(string userId, string? firstName, string? lastName, string? phoneNumber, int? governmentId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null || user.IsDeleted)
                {
                    return Result<bool>.Failure("User not found");
                }

                // Update user properties if provided
                if (!string.IsNullOrEmpty(firstName))
                {
                    user.FirstName = firstName;
                }

                if (!string.IsNullOrEmpty(lastName))
                {
                    user.LastName = lastName;
                }

                if (!string.IsNullOrEmpty(phoneNumber))
                {
                    user.PhoneNumber = phoneNumber;
                }

                if (governmentId.HasValue)
                {
                    // Verify government exists
                    var governmentExists = await _context.Governments.AnyAsync(g => g.Id == governmentId.Value);
                    if (!governmentExists)
                    {
                        return Result<bool>.Failure("Government not found");
                    }

                    user.GovernmentId = governmentId.Value;
                }

                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    return Result<bool>.Failure("Failed to update user: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                }

                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating user data for user {UserId}", userId);
                return Result<bool>.Failure("Error updating user data: " + ex.Message);
            }
        }

        public async Task<Result<string>> AddUserImageAsync(string userId, IFormFile image)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null || user.IsDeleted)
                {
                    return Result<string>.Failure("User not found");
                }

                // Validate image
                if (image == null || image.Length == 0)
                {
                    return Result<string>.Failure("No image was uploaded");
                }

                // Check file type
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var fileExtension = Path.GetExtension(image.FileName).ToLowerInvariant();
                if (!allowedExtensions.Contains(fileExtension))
                {
                    return Result<string>.Failure("Invalid file type. Allowed types: jpg, jpeg, png, gif");
                }

                // Upload image
                var uploadResult = await _fileService.UploadFileAsync(image, "profile-images");
                if (!uploadResult.Succeeded)
                {
                    return Result<string>.Failure(uploadResult.Message!);
                }

                // Update user profile image URL
                user.ProfileImageUrl = uploadResult.Data;
                var updateResult = await _userManager.UpdateAsync(user);
                if (!updateResult.Succeeded)
                {
                    return Result<string>.Failure("Failed to update user profile image: " + string.Join(", ", updateResult.Errors.Select(e => e.Description)));
                }

                return Result<string>.Success(uploadResult.Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding user image for user {UserId}", userId);
                return Result<string>.Failure("Error adding user image: " + ex.Message);
            }
        }
    }
}