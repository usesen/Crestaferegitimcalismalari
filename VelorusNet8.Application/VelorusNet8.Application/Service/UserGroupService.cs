using VelorusNet8.Application.DTOs.Group;
using VelorusNet8.Application.Exception;
using VelorusNet8.Application.Interface.Group;
using VelorusNet8.Application.Interface.Menus;
using VelorusNet8.Domain.Entities.Aggregates.Groups;
using VelorusNet8.Domain.Entities.Aggregates.Menus;

namespace VelorusNet8.Application.Service;

public class UserGroupService : IUserGroupService
{
    private readonly IUserGroupRepository _userGroupRepository;
    private readonly IMenuPermissionRepository _menuPermissionRepository;

    public UserGroupService(IUserGroupRepository userGroupRepository, IMenuPermissionRepository menuPermissionRepository)
    {
        _userGroupRepository = userGroupRepository;
        _menuPermissionRepository = menuPermissionRepository;
    }

    public async Task<int> CreateUserGroupAsync(CreateUserGroupDto createUserGroupDto, CancellationToken cancellationToken)
    {
        var userGroup = new UserGroup
        {
            Name = createUserGroupDto.Name
        };

        await _userGroupRepository.AddAsync(userGroup, cancellationToken);

        var menuPermissions = createUserGroupDto.PermissionIds.Select(menuId => new MenuPermission
        {
            GroupId = userGroup.Id,
            MenuId = menuId
        }).ToList();

        foreach (var permission in menuPermissions)
        {
            await _menuPermissionRepository.AddAsync(permission, cancellationToken);
        }

        return userGroup.Id;
    }

    public async Task<UserGroup> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _userGroupRepository.GetByIdAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<UserGroup>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _userGroupRepository.GetAllAsync(cancellationToken);
    }

    public async Task<int> UpdateUserGroupAsync(UpdateUserGroupDto updateUserGroupDto, CancellationToken cancellationToken)
    {
        var userGroup = await _userGroupRepository.GetByIdAsync(updateUserGroupDto.Id, cancellationToken);
        if (userGroup == null)
        {
            throw new NotFoundException(nameof(UserGroup) + " " + updateUserGroupDto.Id.ToString());
        }

        userGroup.Name = updateUserGroupDto.Name;

        var existingPermissions = await _menuPermissionRepository.GetByUserGroupIdAsync(userGroup.Id, cancellationToken);
        foreach (var permission in existingPermissions)
        {
            await _menuPermissionRepository.DeleteAsync(permission.MenuId, cancellationToken);
        }

        var newPermissions = updateUserGroupDto.PermissionIds.Select(menuId => new MenuPermission
        {
            GroupId = updateUserGroupDto.Id,
            MenuId = menuId
        }).ToList();

        foreach (var permission in newPermissions)
        {
            await _menuPermissionRepository.AddAsync(permission, cancellationToken);
        }

        await _userGroupRepository.UpdateAsync(userGroup, cancellationToken);

        return userGroup.Id;
    }

    public async Task DeleteUserGroupAsync(int id, CancellationToken cancellationToken)
    {
        var existingPermissions = await _menuPermissionRepository.GetByUserGroupIdAsync(id, cancellationToken);
        foreach (var permission in existingPermissions)
        {
            await _menuPermissionRepository.DeleteAsync(permission.MenuId, cancellationToken);
        }

        await _userGroupRepository.DeleteAsync(id, cancellationToken);
    }

    public async Task<UserGroup> GetByNameAsync(string groupName, CancellationToken cancellationToken)
    {
        var userGroup = await _userGroupRepository.GetAllAsync(cancellationToken);
        return userGroup.FirstOrDefault(g => g.Name.Equals(groupName, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<IEnumerable<UserGroup>> GetUserGroupsWithPermissions(int userGroupId, CancellationToken cancellationToken)
    {
        var userGroups = await _userGroupRepository.GetAllAsync(cancellationToken);

        foreach (var group in userGroups)
        {
            var permissions = await _menuPermissionRepository.GetByUserGroupIdAsync(group.Id, cancellationToken);
            group.MenuPermissions = permissions.ToList();
        }

        return userGroups.Where(g => g.Id == userGroupId).ToList();
    }
}

