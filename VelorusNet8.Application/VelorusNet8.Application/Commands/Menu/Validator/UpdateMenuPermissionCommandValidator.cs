

using FluentValidation;

namespace VelorusNet8.Application.Commands.Menu.Validator;


public class UpdateMenuPermissionCommandValidator : AbstractValidator<UpdateMenuPermissionCommand>
{
    public UpdateMenuPermissionCommandValidator()
    {
        RuleFor(x => x.MenuPermissionId)
            .GreaterThan(0).WithMessage("MenuPermission ID is required and must be greater than 0.");

        RuleFor(x => x.MenuId)
            .GreaterThan(0).WithMessage("Menu ID is required and must be greater than 0.");

        RuleFor(x => x.CanView)
            .NotNull().WithMessage("CanView permission is required.");

        RuleFor(x => x.CanEdit)
            .NotNull().WithMessage("CanEdit permission is required.");

        RuleFor(x => x.CanDelete)
            .NotNull().WithMessage("CanDelete permission is required.");

        RuleFor(x => x.CanExcel)
            .NotNull().WithMessage("CanExcel permission is required.");

        RuleFor(x => x.CanPdf)
            .NotNull().WithMessage("CanPdf permission is required.");

        RuleFor(x => x.CanWord)
            .NotNull().WithMessage("CanWord permission is required.");
    }
}