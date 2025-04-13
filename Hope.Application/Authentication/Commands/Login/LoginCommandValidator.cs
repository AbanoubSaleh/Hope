using FluentValidation;
using Hope.Resources;

namespace Hope.Application.Authentication.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(v => v.Email)
                .NotEmpty().WithMessage(Messages.EmailRequired)
                .EmailAddress().WithMessage(Messages.EmailInvalid);

            RuleFor(v => v.Password)
                .NotEmpty().WithMessage(Messages.PasswordRequired);
        }
    }
}