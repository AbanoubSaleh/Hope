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
        Task<Result<List<WeeklyCountDto>>> GetNumberOfNewUsersPerWeekAsync(); // Added this method
        Task<Result<PaginatedList<UserDto>>> GetAllUsersAsync(int pageNumber, int pageSize);
        Task<Result<bool>> DeleteUserAsync(string userId);
        Task<Result<string>> AdminRegisterAsync(string userName, string email, string password, bool isAdmin);
        Task<Result<PaginatedList<UserDto>>> GetAllAdminsAsync(int pageNumber, int pageSize);
        Task<Result<int>> GetAdminsCountAsync();

        // Report management
        Task<Result<int>> GetPostsCountAsync();
        Task<Result<int>> GetDeletedPostsCountAsync();
        Task<Result<List<WeeklyCountDto>>> GetNumberOfNewPostsPerWeekAsync();
        Task<Result<ReportDto>> GetPostByIdAsync(Guid reportId);
        Task<Result<bool>> UnHideReportAsync(Guid reportId);
        Task<Result<PaginatedList<ReportDto>>> GetArchivedReportsAsync(int pageNumber, int pageSize, bool includeComments);
        Task<Result<PaginatedList<ReportDto>>> GetAllPostsAsync(int pageNumber, int pageSize, bool includeComments);
        Task<Result<PaginatedList<ReportDto>>> GetPostThingsAsync(int pageNumber, int pageSize, bool includeComments);
    }
}