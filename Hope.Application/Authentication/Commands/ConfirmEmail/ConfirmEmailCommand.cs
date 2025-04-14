using Hope.Application.Common.Models;
using MediatR;

namespace Hope.Application.Authentication.Commands.ConfirmEmail
{
    public class ConfirmEmailCommand : IRequest<Result>
    {
        public string UserId { get; set; } = null!;
        public string ConfirmationCode { get; set; } = null!;
    }
}