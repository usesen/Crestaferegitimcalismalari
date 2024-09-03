using FluentValidation;

namespace VelorusNet8.Application.Commands.Group.Validator;

public class UpdateUserGroupCommandValidator : AbstractValidator<UpdateUserGroupCommand>
{
    public UpdateUserGroupCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Group ID is required and must be greater than 0.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Group name is required.")
            .MaximumLength(100).WithMessage("Group name must not exceed 100 characters.");
 
        RuleForEach(x => x.Permissions)
            .SetValidator(new UserGroupPermissionValidator());
    }
}
