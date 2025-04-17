using Hope.Application.Common.Models;
using MediatR;

namespace Hope.Application.Admin.Commands
{
    public class AdminRegisterCommand : IRequest<Result<string>>
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsAdmin { get; set; } = true;
    }
}