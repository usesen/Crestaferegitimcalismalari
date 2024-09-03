using MediatR;
using FluentValidation;
using VelorusNet8.Application.Interface.Group;
using VelorusNet8.Domain.Entities.Aggregates.Groups;

namespace VelorusNet8.Application.Commands.Group;
public class UpdateUserAccountGroupCommandHandler : IRequestHandler<UpdateUserAccountGroupCommand, Unit>
{
    private readonly IUserAccountGroupRepository _userAccountGroupRepository;
    private readonly IValidator<UpdateUserAccountGroupCommand> _validator;

    public UpdateUserAccountGroupCommandHandler(IUserAccountGroupRepository userAccountGroupRepository, IValidator<UpdateUserAccountGroupCommand> validator)
    {
        _userAccountGroupRepository = userAccountGroupRepository;
        _validator = validator;
    }

    public async Task<Unit> Handle(UpdateUserAccountGroupCommand request, CancellationToken cancellationToken)
    {
        // Doğrulama işlemi
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        // Mevcut kaydı sil
        await _userAccountGroupRepository.DeleteAsync(request.UserAccountGroupId, cancellationToken);

        // Yeni bir kayıt oluştur
        var userAccountGroup = new UserAccountGroup
        {
            UserAccountId = request.UserId,
            GroupId = request.GroupId
        };

        await _userAccountGroupRepository.AddAsync(userAccountGroup, cancellationToken);

        return Unit.Value;
    }
}

