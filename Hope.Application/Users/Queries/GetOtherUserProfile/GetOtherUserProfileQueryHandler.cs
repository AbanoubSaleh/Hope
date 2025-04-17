using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Hope.Application.Users.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hope.Application.Users.Queries.GetOtherUserProfile
{
    public class GetOtherUserProfileQueryHandler : IRequestHandler<GetOtherUserProfileQuery, Result<UserProfileDto>>
    {
        private readonly IUserService _userService;

        public GetOtherUserProfileQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Result<UserProfileDto>> Handle(GetOtherUserProfileQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserProfileAsync(request.UserId, includeHiddenReports: false);
        }
    }
}