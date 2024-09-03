namespace VelorusNet8.Application.Commands.Group.Validator;

using FluentValidation;

public class UpdateUserAccountGroupCommandValidator : AbstractValidator<UpdateUserAccountGroupCommand>
{
    public UpdateUserAccountGroupCommandValidator()
    {
        RuleFor(x => x.UserAccountGroupId)
            .GreaterThan(0).WithMessage("User Account Group ID must be greater than 0.");

        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("User ID must be greater than 0.");

        RuleFor(x => x.GroupId)
            .GreaterThan(0).WithMessage("Group ID must be greater than 0.");
    }
}
