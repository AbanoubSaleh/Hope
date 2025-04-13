using Hope.Application.Authentication.DTOs;
using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Hope.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Localization;
using System.Security.Claims;

namespace Hope.Application.Authentication.Commands.RefreshToken;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, Result<AuthResponseDto>>
{
    private readonly IAuthService _authService;
    private readonly IStringLocalizer<RefreshTokenCommandHandler> _localizer;

    public RefreshTokenCommandHandler(
        IAuthService authService,
        IStringLocalizer<RefreshTokenCommandHandler> localizer)
    {
        _authService = authService;
        _localizer = localizer;
    }

    public async Task<Result<AuthResponseDto>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var result = await _authService.RefreshTokenAsync(request.Token, request.RefreshToken);
        
        if (!result.Succeeded)
        {
            return Result<AuthResponseDto>.Failure(result.Message, result.Errors);
        }
        
        var (token, refreshToken) = result.Data;
        
        // Validate the new token to get user claims
        var validationResult = await _authService.ValidateJwtToken(token);
        
        if (!validationResult.Succeeded)
        {
            return Result<AuthResponseDto>.Failure(_localizer["Validation.InvalidToken"]);
        }
        
        var principal = validationResult.Data;
        
        var response = new AuthResponseDto
        {
            Token = token,
            RefreshToken = refreshToken,
            Expiration = DateTime.UtcNow.AddDays(7), // Set based on your token expiration
            UserId = principal.FindFirstValue(ClaimTypes.NameIdentifier),
            Email = principal.FindFirstValue(ClaimTypes.Email),
            FirstName = principal.FindFirstValue(ClaimTypes.GivenName),
            LastName = principal.FindFirstValue(ClaimTypes.Surname)
        };
        
        return Result<AuthResponseDto>.Success(response, _localizer["Authentication.TokenRefreshed"]);
    }
}