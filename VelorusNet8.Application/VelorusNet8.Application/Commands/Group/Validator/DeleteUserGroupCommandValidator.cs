namespace VelorusNet8.Application.Commands.Group.Validator;

using FluentValidation;

public class DeleteUserGroupCommandValidator : AbstractValidator<DeleteUserGroupCommand>
{
    public DeleteUserGroupCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Group ID must be greater than 0.");
    }
}
