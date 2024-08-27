using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelorusNet8.Domain.Entities.Aggregates.Users;

namespace VelorusNet8.Application.Interface;
public interface IUserAccountRepository
{
    Task<UserAccount> GetByIdAsync(int userId, CancellationToken cancellationToken);
    Task AddAsync(UserAccount userAccount, CancellationToken cancellationToken);
    Task UpdateAsync(UserAccount userAccount, CancellationToken cancellationToken);
    Task DeleteAsync(int userId, CancellationToken cancellationToken);
    Task<UserAccount> GetByEmailAsync(string email, CancellationToken cancellationToken);
    Task<UserAccount> GetByUserNameAsync(string username, CancellationToken cancellationToken);
    Task<IEnumerable<UserAccount>> GetAllAsync(CancellationToken cancellationToken);
    Task<UserAccount> GetUsersWithBranchesAsync(int id, CancellationToken cancellationToken);
}
