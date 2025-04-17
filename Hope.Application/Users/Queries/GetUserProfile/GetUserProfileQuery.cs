using Hope.Application.Common.Models;
using Hope.Application.Users.DTOs;
using MediatR;

namespace Hope.Application.Users.Queries.GetUserProfile
{
    public class GetUserProfileQuery : IRequest<Result<UserProfileDto>>
    {
        public string UserId { get; set; } = null!;
    }
}