using Hope.Application.Admin.DTOs;
using Hope.Application.Common.Models;
using Hope.Application.MissingPerson.DTOs;
using Hope.Application.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hope.Application.Common.Interfaces
{
    public interface IAdminService
    {
        // User management
        Task<Result<int>> GetUserCountAsync();
        Task<Result<List<WeeklyCountDto>>> GetNumberOfNewUserPerWeekAsync();
        Task<Result<List<UserDto>>> GetAllUsersAsync();
        Task<Result<bool>> DeleteUserAsync(string userId);
        Task<Result<string>> AdminRegisterAsync(string userName, string email, string password, bool isAdmin);
        Task<Result<List<UserDto>>> GetAllAdminsAsync();
        Task<Result<int>> GetAdminsCountAsync();

        // Report management
        Task<Result<int>> GetPostsCountAsync();
        Task<Result<int>> GetDeletedPostsCountAsync();
        Task<Result<List<WeeklyCountDto>>> GetNumberOfNewPostsPerWeekAsync();
        Task<Result<ReportDto>> GetPostByIdAsync(Guid reportId);
        Task<Result<bool>> UnHideReportAsync(Guid reportId);
        Task<Result<IEnumerable<ReportDto>>> GetArchivedReportsAsync();
        Task<Result<IEnumerable<ReportDto>>> GetAllPostsAsync();
        Task<Result<IEnumerable<ReportDto>>> GetPostThingsAsync();
    }
}