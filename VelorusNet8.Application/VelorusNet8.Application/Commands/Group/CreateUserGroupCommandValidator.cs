using FluentValidation;

namespace VelorusNet8.Application.Commands.Group;

public class CreateUserGroupCommandValidator : AbstractValidator<CreateUserGroupCommand>
{
    public CreateUserGroupCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Group name is required.")
            .MaximumLength(100).WithMessage("Group name cannot exceed 100 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(250).WithMessage("Description cannot exceed 250 characters.");

        RuleFor(x => x.PermissionIds)
            .NotNull().WithMessage("Permission IDs cannot be null.")
            .Must(x => x.Count > 0).WithMessage("At least one permission must be assigned.");
    }
}
