using FluentValidation;
using MediatR;
using VelorusNet8.Application.Interface.Group;
using VelorusNet8.Application.Interface.Menus;

namespace VelorusNet8.Application.Commands.Group;

public class DeleteUserGroupCommandHandler : IRequestHandler<DeleteUserGroupCommand, Unit>
{
    private readonly IUserGroupRepository _userGroupRepository;
    private readonly IUserAccountGroupRepository _userAccountGroupRepository;
    private readonly IMenuPermissionRepository _menuPermissionRepository;
    private readonly IValidator<DeleteUserGroupCommand> _validator;

    public DeleteUserGroupCommandHandler(
        IUserGroupRepository userGroupRepository,
        IUserAccountGroupRepository userAccountGroupRepository,
        IMenuPermissionRepository menuPermissionRepository,
        IValidator<DeleteUserGroupCommand> validator)
    {
        _userGroupRepository = userGroupRepository;
        _userAccountGroupRepository = userAccountGroupRepository;
        _menuPermissionRepository = menuPermissionRepository;
        _validator = validator;
    }

    public async Task<Unit> Handle(DeleteUserGroupCommand request, CancellationToken cancellationToken)
    {
        // Doğrulama işlemi
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        // Önce UserGroup ile ilgili tüm ilişkileri temizliyoruz.
        await _userAccountGroupRepository.RemoveByGroupIdAsync(request.Id, cancellationToken);
        var menuPermissions = await _menuPermissionRepository.GetByUserGroupIdAsync(request.Id, cancellationToken);

        foreach (var menuPermission in menuPermissions)
        {
            await _menuPermissionRepository.DeleteAsync(menuPermission.MenuId, cancellationToken);
        }

        // Ardından UserGroup'u siliyoruz.
        await _userGroupRepository.DeleteAsync(request.Id, cancellationToken);

        return Unit.Value;
    }
}


