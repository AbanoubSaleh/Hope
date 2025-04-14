using Hope.Application.Common.Models;
using Hope.Domain.Entities;
using System.Security.Claims;

namespace Hope.Application.Common.Interfaces
{
    public interface IAuthService
    {
        Task<(string token, string refreshToken)> GenerateJwtToken(ApplicationUser user);
        Task<Result<ApplicationUser>> RegisterUserAsync(string email, string password, string firstName, string lastName, int governmentId, string phoneNumber);
        Task<Result<ApplicationUser>> LoginAsync(string email, string password);
        Task<Result> ConfirmEmailAsync(string userId, string token);
        Task<Result> ForgotPasswordAsync(string email);
        Task<Result> ResetPasswordAsync(string email, string token, string newPassword);
        Task<Result<ApplicationUser>> ExternalLoginAsync(string provider, string idToken);
        Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user);
        Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user);
        Task<Result<ClaimsPrincipal>> ValidateJwtToken(string token);
        Task<Result<(string token, string refreshToken)>> RefreshTokenAsync(string token, string refreshToken);
    }
}