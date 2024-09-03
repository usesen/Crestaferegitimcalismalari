using FluentValidation;

namespace VelorusNet8.Application.Commands.Group.Validator;

public class CreateUserAccountGroupCommandValidator : AbstractValidator<CreateUserAccountGroupCommand>
{
    public CreateUserAccountGroupCommandValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("User ID must be greater than 0.");

        RuleFor(x => x.GroupId)
            .GreaterThan(0).WithMessage("Group ID must be greater than 0.");
    }
}
