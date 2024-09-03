using VelorusNet8.Domain.Entities.Aggregates.Groups;

namespace VelorusNet8.Application.Interface.Group;

public interface IUserAccountGroupRepository
{
    Task<UserAccountGroup> GetByIdAsync(int userAccountGroupId, CancellationToken cancellationToken);
    Task AddAsync(UserAccountGroup userAccountGroup, CancellationToken cancellationToken);
    Task DeleteAsync(int userAccountGroupId, CancellationToken cancellationToken);
    Task<IEnumerable<UserAccountGroup>> GetByUserIdAsync(int userId, CancellationToken cancellationToken);
    Task<IEnumerable<UserAccountGroup>> GetByGroupIdAsync(int groupId, CancellationToken cancellationToken);
    Task RemoveByGroupIdAsync(int groupId, CancellationToken cancellationToken);
}

