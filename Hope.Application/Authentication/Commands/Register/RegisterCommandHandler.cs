using Hope.Application.Authentication.DTOs;
using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Hope.Domain.Entities;
using Hope.Resources;
using MediatR;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Localization;
using System.Text;

namespace Hope.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<AuthResponseDto>>
    {
        private readonly IAuthService _authService;
        private readonly IEmailService _emailService;
        private readonly ILookupService _lookupService;
        private readonly IStringLocalizer<RegisterCommandHandler> _localizer;

        public RegisterCommandHandler(
            IAuthService authService,
            IEmailService emailService,
            ILookupService lookupService,
            IStringLocalizer<RegisterCommandHandler> localizer)
        {
            _authService = authService;
            _emailService = emailService;
            _lookupService = lookupService;
            _localizer = localizer;
        }

        public async Task<Result<AuthResponseDto>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            // Check if the government ID exists
            if (!await _lookupService.ExistsAsync<Government>(request.GovernmentId))
            {
                return Result<AuthResponseDto>.Failure(Messages.GovernmentIdNotFound);
            }

            var result = await _authService.RegisterUserAsync(request.Email, request.Password, request.FirstName, request.LastName,request.GovernmentId,request.PhoneNumber);

            if (!result.Succeeded)
            {
                return Result<AuthResponseDto>.Failure(result.Message, result.Errors);
            }

            var user = result.Data;
            
            // Generate email confirmation token
            var token = await _authService.GenerateEmailConfirmationTokenAsync(user);
            
            // Encode the token as it may contain special characters
            var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
            
            // Create confirmation link
            var callbackUrl = $"https://localhost:7217/api/Account/confirm-email?userId={user.Id}&token={encodedToken}";
            
            // Send confirmation email
            await _emailService.SendEmailConfirmationAsync(user.Email, callbackUrl);
            
            // Return success message without tokens
            var response = new AuthResponseDto
            {
                UserId = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            
            return Result<AuthResponseDto>.Success(response, Messages.RegistrationSuccessCheckEmail);
        }
    }
}