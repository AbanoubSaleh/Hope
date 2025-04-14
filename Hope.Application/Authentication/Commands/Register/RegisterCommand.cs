using Hope.Application.Authentication.DTOs;
using Hope.Application.Common.Models;
using MediatR;

namespace Hope.Application.Authentication.Commands.Register
{
    public class RegisterCommand : IRequest<Result<AuthResponseDto>>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int GovernmentId { get; set; } 
        public string PhoneNumber { get; set; } = null!;
    }
}