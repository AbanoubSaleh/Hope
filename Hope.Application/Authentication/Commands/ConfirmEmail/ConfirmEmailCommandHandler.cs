using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Hope.Resources;
using MediatR;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace Hope.Application.Authentication.Commands.ConfirmEmail
{
    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, Result>
    {
        private readonly IAuthService _authService;

        public ConfirmEmailCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<Result> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            // Decode the token
            var decodedToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.Token));
            
            // Confirm the email
            var result = await _authService.ConfirmEmailAsync(request.UserId, decodedToken);
            
            if (!result.Succeeded)
            {
                return Result.Failure(Messages.EmailConfirmationFailed);
            }
            
            return Result.Success(Messages.EmailConfirmationSuccessful);
        }
    }
}