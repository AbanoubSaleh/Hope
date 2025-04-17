using Hope.Application.Common.Models;
using Hope.Application.Users.DTOs;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Hope.Application.Common.Interfaces
{
    public interface IUserService
    {
        Task<Result<UserProfileDto>> GetUserProfileAsync(string userId, bool includeHiddenReports);
        Task<Result<bool>> UpdateUserDataAsync(string userId, string? firstName, string? lastName, string? phoneNumber, int? governmentId);
        Task<Result<string>> AddUserImageAsync(string userId, IFormFile image);
    }
}