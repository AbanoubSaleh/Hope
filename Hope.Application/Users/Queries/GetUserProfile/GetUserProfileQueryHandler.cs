using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Hope.Application.Users.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hope.Application.Users.Queries.GetUserProfile
{
    public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, Result<UserProfileDto>>
    {
        private readonly IUserService _userService;

        public GetUserProfileQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Result<UserProfileDto>> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetUserProfileAsync(request.UserId, includeHiddenReports: true);
        }
    }
}