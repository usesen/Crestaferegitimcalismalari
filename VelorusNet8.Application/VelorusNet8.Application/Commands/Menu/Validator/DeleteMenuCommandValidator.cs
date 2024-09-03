using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelorusNet8.Application.Commands.Menu.Validator;

using FluentValidation;

public class DeleteMenuCommandValidator : AbstractValidator<DeleteMenuCommand>
{
    public DeleteMenuCommandValidator()
    {
        RuleFor(x => x.MenuId)
            .GreaterThan(0).WithMessage("Menu ID must be greater than 0.");
    }
}
