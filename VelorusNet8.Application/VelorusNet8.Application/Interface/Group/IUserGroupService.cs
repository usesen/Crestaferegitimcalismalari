using VelorusNet8.Application.DTOs.Group;
using VelorusNet8.Domain.Entities.Aggregates.Groups;

namespace VelorusNet8.Application.Interface.Group;

public interface IUserGroupService
{
    Task<int> CreateUserGroupAsync(CreateUserGroupDto createUserGroupDto, CancellationToken cancellationToken);
    Task<UserGroup> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<UserGroup>> GetAllAsync(CancellationToken cancellationToken);
    Task<int> UpdateUserGroupAsync(UpdateUserGroupDto updateUserGroupDto, CancellationToken cancellationToken);
    Task DeleteUserGroupAsync(int userGroupId, CancellationToken cancellationToken);
    Task<UserGroup> GetByNameAsync(string groupName, CancellationToken cancellationToken);
    Task<IEnumerable<UserGroup>> GetUserGroupsWithPermissions(int userGroupId, CancellationToken cancellationToken);
}