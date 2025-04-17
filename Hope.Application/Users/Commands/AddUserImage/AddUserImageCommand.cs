using Hope.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Hope.Application.Users.Commands.AddUserImage
{
    public class AddUserImageCommand : IRequest<Result<string>>
    {
        public string UserId { get; set; } = null!;
        public IFormFile Image { get; set; } = null!;
    }
}