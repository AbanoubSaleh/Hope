using Hope.Application.Common.Models;
using MediatR;

namespace Hope.Application.Authentication.Commands.ForgotPassword
{
    public class ForgotPasswordCommand : IRequest<Result>
    {
        public string Email { get; set; } = null!;
    }
}