using VelorusNet8.Domain.Entities.Aggregates.Users;

namespace VelorusNet8.Domain.Repositories;

public interface IUserAccountRepository : IBaseRepository<UserAccount>
{
    Task CreateAsync(UserAccount entity, CancellationToken cancellationToken);
    Task<UserAccount> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<UserAccount>> GetAllAsync(CancellationToken cancellationToken);
    Task UpdateAsync(UserAccount entity, CancellationToken cancellationToken);
    Task DeleteAsync(UserAccount entity, CancellationToken cancellationToken);
    Task<UserAccount> GetByEmailAsync(string email, CancellationToken cancellationToken);
    Task<UserAccount> GetByUserNameAsync(string username, CancellationToken cancellationToken);
    Task<UserAccount> GetUsersWithBranchesAsync(int id, CancellationToken cancellationToken);
}

