using Hope.Application.Common.Models;
using MediatR;

namespace Hope.Application.Users.Commands.UpdateUserData
{
    public class UpdateUserDataCommand : IRequest<Result<bool>>
    {
        public string UserId { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public int? GovernmentId { get; set; }
    }
}