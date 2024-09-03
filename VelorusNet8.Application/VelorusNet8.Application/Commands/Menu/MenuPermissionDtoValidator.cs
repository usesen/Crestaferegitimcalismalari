using FluentValidation;
using VelorusNet8.Application.DTOs.Menu;

namespace VelorusNet8.Application.Commands.Menu;

public class MenuPermissionDtoValidator : AbstractValidator<MenuPermissionDto>
{
    public MenuPermissionDtoValidator()
    {
        RuleFor(x => x.PermissionName)
            .NotEmpty().WithMessage("Permission name is required.")
            .MaximumLength(50).WithMessage("Permission name must not exceed 50 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(200).WithMessage("Description must not exceed 200 characters.");
    }
}
