using FluentValidation;
using MediatR;
using VelorusNet8.Application.Interface.Group;
using VelorusNet8.Domain.Entities.Aggregates.Groups;

namespace VelorusNet8.Application.Commands.Group;

public class CreateUserAccountGroupCommandHandler : IRequestHandler<CreateUserAccountGroupCommand, int>
{
    private readonly IUserAccountGroupRepository _userAccountGroupRepository;
    private readonly IValidator<CreateUserAccountGroupCommand> _validator;

    public CreateUserAccountGroupCommandHandler(IUserAccountGroupRepository userAccountGroupRepository, IValidator<CreateUserAccountGroupCommand> validator)
    {
        _userAccountGroupRepository = userAccountGroupRepository;
        _validator = validator;
    }

    public async Task<int> Handle(CreateUserAccountGroupCommand request, CancellationToken cancellationToken)
    {
        // Doğrulama işlemi
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        var userAccountGroup = new UserAccountGroup
        {
            UserAccountId = request.UserId,
            GroupId = request.GroupId
        };

        await _userAccountGroupRepository.AddAsync(userAccountGroup, cancellationToken);

        return userAccountGroup.GroupId;
    }
}
