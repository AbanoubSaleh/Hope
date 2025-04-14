using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Hope.Resources;
using MediatR;

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
            // Retrieve the stored token associated with the confirmation code
            var tokenResult = await _authService.GetTokenByConfirmationCodeAsync(request.UserId, request.ConfirmationCode);
            
            if (!tokenResult.Succeeded)
            {
                return Result.Failure(Messages.InvalidConfirmationCode);
            }
            
            // Confirm the email using the retrieved token
            var result = await _authService.ConfirmEmailAsync(request.UserId, tokenResult.Data);
            
            if (!result.Succeeded)
            {
                return Result.Failure(Messages.EmailConfirmationFailed);
            }
            
            // Mark the confirmation code as used
            await _authService.RemoveConfirmationCodeAsync(request.UserId);
            
            return Result.Success(Messages.EmailConfirmationSuccessful);
        }
    }
}