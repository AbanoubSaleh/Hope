using Hope.Application.Authentication.DTOs;
using Hope.Application.Common.Models;
using MediatR;

namespace Hope.Application.Authentication.Commands.Login
{
    public class LoginCommand : IRequest<Result<AuthResponseDto>>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool RememberMe { get; set; }  
    }
}