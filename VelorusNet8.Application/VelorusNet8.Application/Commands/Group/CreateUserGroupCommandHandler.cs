using FluentValidation;
using MediatR;
using VelorusNet8.Application.Interface.Group;
using VelorusNet8.Domain.Entities.Aggregates.Groups;

namespace VelorusNet8.Application.Commands.Group;

public class CreateUserGroupCommandHandler : IRequestHandler<CreateUserGroupCommand, int>
{
    private readonly IUserGroupRepository _userGroupRepository;
    private readonly IValidator<CreateUserGroupCommand> _validator;

    public CreateUserGroupCommandHandler(IUserGroupRepository userGroupRepository, IValidator<CreateUserGroupCommand> validator)
    {
        _userGroupRepository = userGroupRepository;
        _validator = validator;
    }

    public async Task<int> Handle(CreateUserGroupCommand request, CancellationToken cancellationToken)
    {
        // Doğrulama işlemi
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
        {
            // Hataları bir exception olarak döndürüyoruz
            throw new ValidationException(validationResult.Errors);
        }

        // Yeni UserGroup nesnesi oluşturuluyor
        var userGroup = new UserGroup
        {
            Name = request.Name
           
            // PermissionIds alanına göre ilgili izinleri ekleyebilirsiniz.
            // Permissions = request.PermissionIds.Select(id => new Permission { Id = id }).ToList()
        };

        // UserGroup'u repository'ye ekliyoruz
        await _userGroupRepository.AddAsync(userGroup, cancellationToken);

        // Yeni oluşturulan grubun kimliğini geri döndürüyoruz
        return userGroup.Id;
    }
}
