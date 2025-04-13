using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Hope.Application.Authentication.Commands.ExternalLogin
{
    public class ExternalLoginCommandValidator : AbstractValidator<ExternalLoginCommand>
    {
        private readonly IStringLocalizer<ExternalLoginCommandValidator> _localizer;

        public ExternalLoginCommandValidator(IStringLocalizer<ExternalLoginCommandValidator> localizer)
        {
            _localizer = localizer;

            RuleFor(v => v.Provider)
                .NotEmpty().WithMessage(_localizer["Validation.Required", "Provider"]);

            RuleFor(v => v.IdToken)
                .NotEmpty().WithMessage(_localizer["Validation.Required", "IdToken"]);
        }
    }
}