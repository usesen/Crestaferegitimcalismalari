using System.Threading.Tasks;
using VelorusNet8.Application.Dto.User;
using VelorusNet8.Domain.Entities.Aggregates.Users;

namespace VelorusNet8.Application.Interface;

public interface IUserAccountService
{
    Task<int> CreateUserAsync(CreateUserAccountDto createUserDto, CancellationToken cancellationToken);
    Task<UserAccount> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<UserAccount>> GetAllAsync(CancellationToken cancellationToken);
    Task<UserAccount> UpdateAsync(UserAccount entity, CancellationToken cancellationToken);
    Task DeleteAsync(int userId, CancellationToken cancellationToken);
    Task<UserAccount> GetByEmailAsync(string email, CancellationToken cancellationToken);
    Task<UserAccount> GetByUserNameAsync(string username, CancellationToken cancellationToken);
    Task<UserAccount> GetUsersWithBranches(int id, CancellationToken cancellationToken);
}
