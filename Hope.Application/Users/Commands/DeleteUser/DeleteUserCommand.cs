using Hope.Application.Common.Models;
using MediatR;

namespace Hope.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<Result<bool>>
    {
        public string UserId { get; set; } = string.Empty;
    }
}