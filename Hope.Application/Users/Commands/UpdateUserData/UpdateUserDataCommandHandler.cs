using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hope.Application.Users.Commands.UpdateUserData
{
    public class UpdateUserDataCommandHandler : IRequestHandler<UpdateUserDataCommand, Result<bool>>
    {
        private readonly IUserService _userService;

        public UpdateUserDataCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Result<bool>> Handle(UpdateUserDataCommand request, CancellationToken cancellationToken)
        {
            return await _userService.UpdateUserDataAsync(request.UserId, request.FirstName, request.LastName, request.PhoneNumber, request.GovernmentId);
        }
    }
}