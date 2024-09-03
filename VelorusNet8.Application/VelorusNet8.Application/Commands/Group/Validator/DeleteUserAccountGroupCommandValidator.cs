using FluentValidation;

namespace VelorusNet8.Application.Commands.Group.Validator;

public class DeleteUserAccountGroupCommandValidator : AbstractValidator<DeleteUserAccountGroupCommand>
{
    public DeleteUserAccountGroupCommandValidator()
    {
        RuleFor(x => x.UserAccountGroupId)
            .GreaterThan(0).WithMessage("User Account Group ID must be greater than 0.");
    }
}

