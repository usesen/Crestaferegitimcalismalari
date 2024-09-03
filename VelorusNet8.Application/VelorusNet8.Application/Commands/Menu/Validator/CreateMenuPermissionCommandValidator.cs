using FluentValidation;

namespace VelorusNet8.Application.Commands.Menu.Validator;

public class CreateMenuPermissionCommandValidator : AbstractValidator<CreateMenuPermissionCommand>
{
    public CreateMenuPermissionCommandValidator()
    {
        RuleFor(x => x.MenuId).GreaterThan(0).WithMessage("Menu ID must be greater than 0.");
        RuleFor(x => x.CanView).NotNull();
        RuleFor(x => x.CanEdit).NotNull();
        RuleFor(x => x.CanDelete).NotNull();
        RuleFor(x => x.CanExcel).NotNull();
        RuleFor(x => x.CanPdf).NotNull();
        RuleFor(x => x.CanWord).NotNull();
    }
}