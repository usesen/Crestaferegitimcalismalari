namespace VelorusNet8.Application.Commands.UserAccount;

using FluentValidation;

public class UpdateUserAccountCommandValidator : AbstractValidator<UpdateUserAccountCommand>
{
    public UpdateUserAccountCommandValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("UserName is required.")
            .Length(2, 50).WithMessage("UserName must be between 2 and 50 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email address.");

        RuleFor(x => x.PasswordHash)
            .NotEmpty().WithMessage("Passsword is required.")
            .Length(5, 20).WithMessage("Invalid Password Length.");

        RuleFor(x => x.IsActive)
            .NotNull().WithMessage("IsActive status is required.");
    }
}

