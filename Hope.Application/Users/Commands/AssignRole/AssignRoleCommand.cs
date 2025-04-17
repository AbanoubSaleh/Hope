using Hope.Application.Common.Models;
using MediatR;

namespace Hope.Application.Users.Commands.AssignRole
{
    public class AssignRoleCommand : IRequest<Result<bool>>
    {
        public string UserId { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
    }
}