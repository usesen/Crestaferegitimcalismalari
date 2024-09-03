using FluentValidation;
using MediatR;
using VelorusNet8.Application.Interface.Group;

namespace VelorusNet8.Application.Commands.Group;

public class DeleteUserAccountGroupCommandHandler : IRequestHandler<DeleteUserAccountGroupCommand, Unit>
{
    private readonly IUserAccountGroupRepository _userAccountGroupRepository;
    private readonly IValidator<DeleteUserAccountGroupCommand> _validator;
    public DeleteUserAccountGroupCommandHandler(IUserAccountGroupRepository userAccountGroupRepository, IValidator<DeleteUserAccountGroupCommand> validator)
    {
        _userAccountGroupRepository = userAccountGroupRepository;
        _validator = validator;
    }

    public async Task<Unit> Handle(DeleteUserAccountGroupCommand request, CancellationToken cancellationToken)
    {   // Doğrulama işlemi
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        await _userAccountGroupRepository.DeleteAsync(request.UserAccountGroupId, cancellationToken);
        return Unit.Value;
    }
}

