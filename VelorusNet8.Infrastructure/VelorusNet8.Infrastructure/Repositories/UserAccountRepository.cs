using VelorusNet8.Domain.Entities.Aggregates.Users;
using VelorusNet8.Domain.Repositories;
using VelorusNet8.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using VelorusNet8.Application.Service;

namespace VelorusNet8.Infrastructure.Repositories;


    public class UserAccountRepository : IUserAccountRepository
    {
    private readonly UserAccounService _userAccountService;

    public UserAccountRepository(UserAccounService userAccountService)
    {
        _userAccountService = userAccountService;
    }

    public Task CreateAsync(UserAccount entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(UserAccount entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserAccount>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<UserAccount> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<UserAccount> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<UserAccount> GetByUserNameAsync(string username, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<UserAccount> GetUsersWithBranchesAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UserAccount entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

