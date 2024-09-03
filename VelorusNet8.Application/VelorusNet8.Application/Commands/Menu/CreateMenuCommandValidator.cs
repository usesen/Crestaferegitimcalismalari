using FluentValidation;

namespace VelorusNet8.Application.Commands.Menu;

public class CreateMenuCommandValidator : AbstractValidator<CreateMenuCommand>
{
    public CreateMenuCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Menu title is required.")
            .MaximumLength(100).WithMessage("Menu title must not exceed 100 characters.");

        RuleFor(x => x.Url)
            .NotEmpty().WithMessage("Menu URL is required.")
            .MaximumLength(200).WithMessage("Menu URL must not exceed 200 characters.");

        RuleForEach(x => x.MenuPermissions)
            .SetValidator(new MenuPermissionDtoValidator());
    }
}
