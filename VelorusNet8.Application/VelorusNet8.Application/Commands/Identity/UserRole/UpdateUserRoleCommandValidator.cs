

using FluentValidation;
using VelorusNet8.Application.Commands.Identity.RoleRepository;

namespace VelorusNet8.Application.Commands.Identity.RolePermission;

public  class UpdateUserRolePermissionCommandValidator : AbstractValidator<UpdateRolePermissionCommand>
{
    public UpdateUserRolePermissionCommandValidator()
    {
        RuleFor(x => x.RoleId)
            .GreaterThan(0).WithMessage("RoleId must be greater than zero.");

        RuleFor(x => x.PermissionId)
            .GreaterThan(0).WithMessage("PermissionId must be greater than zero.");
    }
}
