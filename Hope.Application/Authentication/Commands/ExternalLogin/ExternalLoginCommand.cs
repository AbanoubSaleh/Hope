using Hope.Application.Authentication.DTOs;
using Hope.Application.Common.Models;
using MediatR;

namespace Hope.Application.Authentication.Commands.ExternalLogin
{
    public class ExternalLoginCommand : IRequest<Result<AuthResponseDto>>
    {
        public string Provider { get; set; }
        public string IdToken { get; set; }
    }
}