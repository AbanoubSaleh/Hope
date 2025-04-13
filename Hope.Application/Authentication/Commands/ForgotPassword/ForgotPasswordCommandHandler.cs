using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Hope.Resources;
using MediatR;

namespace Hope.Application.Authentication.Commands.ForgotPassword
{
    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, Result>
    {
        private readonly IAuthService _authService;

        public ForgotPasswordCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<Result> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await _authService.ForgotPasswordAsync(request.Email);
            
            if (!result.Succeeded)
            {
                return Result.Failure(result.Message, result.Errors);
            }
            
            return Result.Success(Messages.PasswordResetRequested);
        }
    }
}