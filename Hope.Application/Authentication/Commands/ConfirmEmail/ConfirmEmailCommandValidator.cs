using FluentValidation;
using Hope.Resources;

namespace Hope.Application.Authentication.Commands.ConfirmEmail
{
    public class ConfirmEmailCommandValidator : AbstractValidator<ConfirmEmailCommand>
    {
        public ConfirmEmailCommandValidator()
        {
            RuleFor(v => v.UserId)
                .NotEmpty().WithMessage(Messages.UserIdRequired);

            RuleFor(v => v.ConfirmationCode)
                .NotEmpty().WithMessage(Messages.ConfirmationCodeRequired)
                .Length(6).WithMessage(Messages.ConfirmationCodeLength);
        }
    }
}