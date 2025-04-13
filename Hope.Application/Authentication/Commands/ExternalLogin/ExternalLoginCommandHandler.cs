using Hope.Application.Authentication.DTOs;
using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Hope.Application.Authentication.Commands.ExternalLogin
{
    public class ExternalLoginCommandHandler : IRequestHandler<ExternalLoginCommand, Result<AuthResponseDto>>
    {
        private readonly IAuthService _authService;
        private readonly IStringLocalizer<ExternalLoginCommandHandler> _localizer;

        public ExternalLoginCommandHandler(
            IAuthService authService,
            IStringLocalizer<ExternalLoginCommandHandler> localizer)
        {
            _authService = authService;
            _localizer = localizer;
        }

        public async Task<Result<AuthResponseDto>> Handle(ExternalLoginCommand request, CancellationToken cancellationToken)
        {
            var result = await _authService.ExternalLoginAsync(request.Provider, request.IdToken);
            
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
            
            return Result<AuthResponseDto>.Success(response, _localizer["Authentication.LoginSuccess"]);
        }
    }
}