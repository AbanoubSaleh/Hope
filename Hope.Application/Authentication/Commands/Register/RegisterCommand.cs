using Hope.Application.Authentication.DTOs;
using Hope.Application.Common.Models;
using MediatR;

namespace Hope.Application.Authentication.Commands.Register
{
    public class RegisterCommand : IRequest<Result<AuthResponseDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}