using FluentValidation;
using VelorusNet8.Application.DTOs.Group;

namespace VelorusNet8.Application.Commands.Group.Validator;

public class UserGroupPermissionValidator : AbstractValidator<UserGroupPermissionDto>
{
    public UserGroupPermissionValidator()
    {
        RuleFor(x => x.PermissionName)
            .NotEmpty().WithMessage("Permission name is required.")
            .MaximumLength(50).WithMessage("Permission name must not exceed 50 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(200).WithMessage("Description must not exceed 200 characters.");

        RuleFor(x => x.IsGranted)
            .NotNull().WithMessage("IsGranted field must be specified.");
    }
}

