using FluentValidation;
using Hope.Resources;

namespace Hope.Application.Authentication.Commands.ForgotPassword
{
    public class ForgotPasswordCommandValidator : AbstractValidator<ForgotPasswordCommand>
    {
        public ForgotPasswordCommandValidator()
        {
            RuleFor(v => v.Email)
                .NotEmpty().WithMessage(Messages.EmailRequired)
                .EmailAddress().WithMessage(Messages.EmailInvalid);
        }
    }
}