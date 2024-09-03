using FluentValidation;

namespace VelorusNet8.Application.Commands.Menu.Validator;

public class DeleteMenuPermissionCommandValidator : AbstractValidator<DeleteMenuPermissionCommand>
{
    public DeleteMenuPermissionCommandValidator()
    {
        RuleFor(x => x.MenuPermissionId)
            .GreaterThan(0).WithMessage("Permission ID must be greater than 0.");
    }
}