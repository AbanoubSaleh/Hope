using Hope.Application.Authentication.DTOs;
using Hope.Application.Common.Models;
using MediatR;

namespace Hope.Application.Authentication.Commands.RefreshToken
{
    public class RefreshTokenCommand : IRequest<Result<AuthResponseDto>>
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}