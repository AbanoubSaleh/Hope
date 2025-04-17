using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hope.Application.Users.Commands.AddUserImage
{
    public class AddUserImageCommandHandler : IRequestHandler<AddUserImageCommand, Result<string>>
    {
        private readonly IUserService _userService;

        public AddUserImageCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Result<string>> Handle(AddUserImageCommand request, CancellationToken cancellationToken)
        {
            return await _userService.AddUserImageAsync(request.UserId, request.Image);
        }
    }
}