using FluentValidation;

namespace VelorusNet8.Application.Commands.UserAccount;

public  class UserAccountCommandValidator : AbstractValidator<VelorusNet8.Application.Dto.User.UserAccountDto>
{
    public UserAccountCommandValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Username is required.")
            .Length(3, 50).WithMessage("Username must be between 3 and 50 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email address.");

        RuleFor(x => x.PasswordHash)
            .NotEmpty().WithMessage("Password is required.")
            .Length(6, 100).WithMessage("Password must be between 6 and 100 characters.");

        RuleFor(x => x.IsActive)
            .NotNull().WithMessage("IsActive status is required.");
    }
}
