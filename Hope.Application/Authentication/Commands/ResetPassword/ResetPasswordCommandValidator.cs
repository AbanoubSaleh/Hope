using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Hope.Application.Authentication.Commands.ResetPassword
{
    public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
    {
        private readonly IStringLocalizer<ResetPasswordCommandValidator> _localizer;

        public ResetPasswordCommandValidator(IStringLocalizer<ResetPasswordCommandValidator> localizer)
        {
            _localizer = localizer;

            RuleFor(v => v.Email)
                .NotEmpty().WithMessage(_localizer["EmailRequired"])
                .EmailAddress().WithMessage(_localizer["EmailInvalid"]);

            RuleFor(v => v.Token)
                .NotEmpty().WithMessage(_localizer["TokenRequired"]);

            RuleFor(v => v.Password)
                .NotEmpty().WithMessage(_localizer["PasswordRequired"])
                .MinimumLength(8).WithMessage(_localizer["PasswordMinLength"])
                .Matches("[A-Z]").WithMessage(_localizer["PasswordUppercase"])
                .Matches("[a-z]").WithMessage(_localizer["PasswordLowercase"])
                .Matches("[0-9]").WithMessage(_localizer["PasswordDigit"])
                .Matches("[^a-zA-Z0-9]").WithMessage(_localizer["PasswordSpecialChar"]);

            RuleFor(v => v.ConfirmPassword)
                .Equal(v => v.Password).WithMessage(_localizer["Validation.PasswordMismatch"]);
        }
    }
}