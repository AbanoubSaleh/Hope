using Hope.Application.Common.Models;
using Hope.Application.Users.DTOs;
using MediatR;

namespace Hope.Application.Users.Queries.GetOtherUserProfile
{
    public class GetOtherUserProfileQuery : IRequest<Result<UserProfileDto>>
    {
        public string UserId { get; set; } = null!;
    }
}