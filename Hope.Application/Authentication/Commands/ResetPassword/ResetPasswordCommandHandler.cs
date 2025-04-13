using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Hope.Resources;
using MediatR;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace Hope.Application.Authentication.Commands.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, Result>
    {
        private readonly IAuthService _authService;

        public ResetPasswordCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<Result> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
        
            var result = await _authService.ResetPasswordAsync(request.Email, request.Token, request.Password);
            
            if (!result.Succeeded)
            {
                return Result.Failure(result.Message, result.Errors);
            }
            
            return Result.Success(Messages.PasswordResetSuccess);
        }
    }
}