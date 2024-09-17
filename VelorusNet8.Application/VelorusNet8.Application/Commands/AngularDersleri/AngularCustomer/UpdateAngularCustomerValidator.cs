using FluentValidation;

namespace VelorusNet8.Application.Commands.AngularDersleri.AngularCustomer;

public class UpdateAngularCustomerCommandValidator : AbstractValidator<UpdateAngularCustomerCommand>
{
    public UpdateAngularCustomerCommandValidator()
    {
        RuleFor(c => c.firstName)
             .NotEmpty().WithMessage("First name is required.")
             .MaximumLength(100).WithMessage("First name cannot exceed 100 characters.");

        RuleFor(c => c.lastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(100).WithMessage("Last name cannot exceed 100 characters.");

        RuleFor(c => c.email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(c => c.phone)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^\d{10}$").WithMessage("Phone number must be 10 digits.");

        RuleFor(c => c.address)
            .MaximumLength(250).WithMessage("Address cannot exceed 250 characters.");

        RuleFor(c => c.city)
            .MaximumLength(100).WithMessage("City cannot exceed 100 characters.");

        RuleFor(c => c.country)
            .MaximumLength(100).WithMessage("Country cannot exceed 100 characters.");

        RuleFor(c => c.postalCode)
            .Matches(@"^\d{5}$").WithMessage("Postal Code must be 5 digits.");
    }
}

