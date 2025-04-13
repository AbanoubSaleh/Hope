using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Hope.Application.Authentication.Commands.RefreshToken
{
    public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
    {
        private readonly IStringLocalizer<RefreshTokenCommandValidator> _localizer;

        public RefreshTokenCommandValidator(IStringLocalizer<RefreshTokenCommandValidator> localizer)
        {
            _localizer = localizer;

            RuleFor(v => v.Token)
                .NotEmpty().WithMessage(_localizer["Validation.Required", "Token"]);

            RuleFor(v => v.RefreshToken)
                .NotEmpty().WithMessage(_localizer["Validation.Required", "RefreshToken"]);
        }
    }
}