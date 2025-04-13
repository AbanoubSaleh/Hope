using Hope.Application.Authentication.DTOs;
using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Hope.Resources;
using MediatR;

namespace Hope.Application.Authentication.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<AuthResponseDto>>
    {
        private readonly IAuthService _authService;

        public LoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<Result<AuthResponseDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = await _authService.LoginAsync(request.Email, request.Password);

            if (!result.Succeeded)
            {
                return Result<AuthResponseDto>.Failure(result.Message, result.Errors);
            }

            var user = result.Data;
            
            // Generate JWT token
            var (token, refreshToken) = await _authService.GenerateJwtToken(user);
            
            var response = new AuthResponseDto
            {
                Token = token,
                RefreshToken = refreshToken,
                Expiration = DateTime.UtcNow.AddDays(7), // Set based on your token expiration
                UserId = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            
            return Result<AuthResponseDto>.Success(response, Messages.LoginSuccess);
        }
    }
}