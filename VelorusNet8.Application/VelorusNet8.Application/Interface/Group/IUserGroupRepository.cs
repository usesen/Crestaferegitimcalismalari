using VelorusNet8.Domain.Entities.Aggregates.Groups;

namespace VelorusNet8.Application.Interface.Group;

public interface IUserGroupRepository
{
    Task<UserGroup> GetByIdAsync(int userGroupId, CancellationToken cancellationToken);
    Task AddAsync(UserGroup userGroup, CancellationToken cancellationToken);
    Task UpdateAsync(UserGroup userGroup, CancellationToken cancellationToken);
    Task DeleteAsync(int userGroupId, CancellationToken cancellationToken);
    Task<UserGroup> GetByNameAsync(string groupName, CancellationToken cancellationToken);
    Task<IEnumerable<UserGroup>> GetAllAsync(CancellationToken cancellationToken);
    Task<UserGroup> GetUserGroupsWithPermissionsAsync(int userGroupId, CancellationToken cancellationToken);
}
