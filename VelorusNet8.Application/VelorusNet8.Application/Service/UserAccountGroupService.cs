using VelorusNet8.Application.Interface.Group;
using VelorusNet8.Domain.Entities.Aggregates.Groups;

namespace VelorusNet8.Application.Service;

public class UserAccountGroupService : IUserAccountGroupService
{
    private readonly IUserAccountGroupRepository _userAccountGroupRepository;

    public UserAccountGroupService(IUserAccountGroupRepository userAccountGroupRepository)
    {
        _userAccountGroupRepository = userAccountGroupRepository;
    }

    public async Task<UserAccountGroup> GetByIdAsync(int userAccountGroupId, CancellationToken cancellationToken)
    {
        return await _userAccountGroupRepository.GetByIdAsync(userAccountGroupId, cancellationToken);
    }

    public async Task<int> CreateUserAccountGroupAsync(int userId, int groupId, CancellationToken cancellationToken)
    {
        var userAccountGroup = new UserAccountGroup
        {
            UserAccountId = userId,
            GroupId = groupId
        };

        await _userAccountGroupRepository.AddAsync(userAccountGroup, cancellationToken);

        return userAccountGroup.UserAccountId;
    }

    public async Task RemoveUserFromGroupAsync(int userId, int groupId, CancellationToken cancellationToken)
    {
        var userAccountGroups = await _userAccountGroupRepository.GetByUserIdAsync(userId, cancellationToken);
        var groupToRemove = userAccountGroups.FirstOrDefault(uag => uag.GroupId == groupId);

        if (groupToRemove != null)
        {
            await _userAccountGroupRepository.DeleteAsync(groupToRemove.UserAccountId, cancellationToken);
        }
    }

    public async Task DeleteAsync(int userAccountGroupId, CancellationToken cancellationToken)
    {
        await _userAccountGroupRepository.DeleteAsync(userAccountGroupId, cancellationToken);
    }

    public async Task<IEnumerable<UserAccountGroup>> GetGroupsByUserIdAsync(int userId, CancellationToken cancellationToken)
    {
        return await _userAccountGroupRepository.GetByUserIdAsync(userId, cancellationToken);
    }

    public async Task<IEnumerable<UserAccountGroup>> GetUsersByGroupIdAsync(int groupId, CancellationToken cancellationToken)
    {
        return await _userAccountGroupRepository.GetByGroupIdAsync(groupId, cancellationToken);
    }

    public async Task RemoveByGroupIdAsync(int groupId, CancellationToken cancellationToken)
    {
        await _userAccountGroupRepository.RemoveByGroupIdAsync(groupId, cancellationToken);
    }
}
