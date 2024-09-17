using FluentValidation;
using MediatR;
using VelorusNet8.Application.Exception;
using VelorusNet8.Application.Interface.Group;
using VelorusNet8.Application.Interface.Menus;
using VelorusNet8.Domain.Entities.Aggregates.Groups;
using VelorusNet8.Domain.Entities.Aggregates.Menus;

namespace VelorusNet8.Application.Commands.Group;

public class UpdateUserGroupCommandHandler : IRequestHandler<UpdateUserGroupCommand, int>
{
    private readonly IUserGroupRepository _userGroupRepository;
    private readonly IMenuPermissionRepository _menuPermissionRepository;
    private readonly IValidator<UpdateUserGroupCommand> _validator;

    public UpdateUserGroupCommandHandler(IUserGroupRepository userGroupRepository, IValidator<UpdateUserGroupCommand> validator, IMenuPermissionRepository menuPermissionRepository)
    {
        _userGroupRepository = userGroupRepository;
        _validator = validator;
        _menuPermissionRepository = menuPermissionRepository;
    }

    public async Task<int> Handle(UpdateUserGroupCommand request, CancellationToken cancellationToken)
    {
        // Doğrulama işlemi
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
        {
            throw new  FluentValidation.ValidationException(validationResult.Errors.ToString());
        }

        // Mevcut UserGroup nesnesini veritabanından getiriyoruz
        var userGroup = await _userGroupRepository.GetByIdAsync(request.Id, cancellationToken);
        if (userGroup == null)
        {
            throw new NotFoundException(nameof(UserGroup) + " " + request.Id.ToString());
        }

        // Grubun adı ve izinlerini güncelliyoruz
        userGroup.Name = request.Name;
        // Grubun mevcut izinlerini temizliyoruz
        var existingPermissions = await _menuPermissionRepository.GetByUserGroupIdAsync(userGroup.Id, cancellationToken);
     
        foreach (var permission in existingPermissions)
        {
            await _menuPermissionRepository.DeleteAsync(permission.MenuId, cancellationToken);
        }
        // Yeni izinleri ekliyoruz
        var newPermissions = request.MenuIds.Select(menuId => new MenuPermission
        {
            GroupId = userGroup.Id,
            MenuId = menuId
        }).ToList();

        foreach (var permission in newPermissions)
        {
            await _menuPermissionRepository.AddAsync(permission, cancellationToken);
        }
        // Güncellenen grubu veritabanında kaydediyoruz
        await _userGroupRepository.UpdateAsync(userGroup, cancellationToken);

        return userGroup.Id;  // Güncellenen grubun kimliğini döndürüyoruz
    }
}
