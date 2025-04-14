using FluentValidation;
using Hope.Resources;

namespace Hope.Application.Authentication.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage(Messages.FirstNameRequired)
            .MaximumLength(50).WithMessage(Messages.FirstNameTooLong);

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage(Messages.LastNameRequired)
            .MaximumLength(50).WithMessage(Messages.LastNameTooLong);

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(Messages.EmailRequired)
            .EmailAddress().WithMessage(Messages.EmailInvalid);

        RuleFor(x => x.GovernmentId)
            .NotEmpty().WithMessage(Messages.GovernmentIdRequired);

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage(Messages.PhoneNumberRequired);

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(Messages.PasswordRequired)
            .MinimumLength(8).WithMessage(Messages.PasswordTooShort)
            .Matches("[A-Z]").WithMessage(Messages.PasswordRequiresUpper)
            .Matches("[a-z]").WithMessage(Messages.PasswordRequiresLower)
            .Matches("[0-9]").WithMessage(Messages.PasswordRequiresDigit)
            .Matches("[^a-zA-Z0-9]").WithMessage(Messages.PasswordRequiresSpecial);

        RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.Password).WithMessage(Messages.PasswordsDoNotMatch);
    }
}