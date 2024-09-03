namespace VelorusNet8.Application.Commands.Menu.Validator;

using FluentValidation;

public class UpdateMenuCommandValidator : AbstractValidator<UpdateMenuCommand>
{
    public UpdateMenuCommandValidator()
    {
        RuleFor(x => x.MenuId)
            .GreaterThan(0).WithMessage("Menu ID must be greater than 0.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Menu title is required.")
            .MaximumLength(100).WithMessage("Menu title must not exceed 100 characters.");

        RuleFor(x => x.Url)
            .NotEmpty().WithMessage("Menu URL is required.")
            .MaximumLength(200).WithMessage("Menu URL must not exceed 200 characters.");
    }
}

