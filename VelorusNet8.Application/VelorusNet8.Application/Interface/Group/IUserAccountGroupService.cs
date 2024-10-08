﻿using VelorusNet8.Domain.Entities.Aggregates.Groups;

namespace VelorusNet8.Application.Interface.Group;

public interface IUserAccountGroupService
{
 
        Task<UserAccountGroup> GetByIdAsync(int userAccountGroupId, CancellationToken cancellationToken);
        Task<int> CreateUserAccountGroupAsync(int userId, int groupId, CancellationToken cancellationToken);
        Task RemoveUserFromGroupAsync(int userId, int groupId, CancellationToken cancellationToken);
        Task DeleteAsync(int userAccountGroupId, CancellationToken cancellationToken);
        Task<IEnumerable<UserAccountGroup>> GetGroupsByUserIdAsync(int userId, CancellationToken cancellationToken);
        Task<IEnumerable<UserAccountGroup>> GetUsersByGroupIdAsync(int groupId, CancellationToken cancellationToken);
        Task RemoveByGroupIdAsync(int groupId, CancellationToken cancellationToken);

}

