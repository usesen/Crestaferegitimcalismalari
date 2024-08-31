using VelorusNet8.Domain.Entities.Aggregates.Users;
using VelorusNet8.Application.Service;
using VelorusNet8.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using VelorusNet8.Application.Interface.User;

namespace VelorusNet8.Infrastructure.Repositories;


public class UserAccountRepository : IUserAccountRepository
{
    private AppDbContext _context;

    public UserAccountRepository(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }

    public async Task<UserAccount> GetByIdAsync(int userId, CancellationToken cancellationToken)
    {
        return await _context.UserAccounts.FindAsync(new object[] { userId }, cancellationToken);
    }

    public async Task AddAsync(UserAccount userAccount, CancellationToken cancellationToken)
    {
        await _context.UserAccounts.AddAsync(userAccount, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(UserAccount userAccount, CancellationToken cancellationToken)
    {
        _context.UserAccounts.Update(userAccount);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int userId, CancellationToken cancellationToken)
    {
        // Veritabanından userId ile eşleşen ilk kullanıcıyı getiriyoruz
        var userAccount = await _context.UserAccounts
            .FirstOrDefaultAsync(u => u.UserId == userId, cancellationToken);


        // Kullanıcı bulunduysa, IsActive özelliğini false olarak ayarlıyoruz
        if (userAccount != null)
        {
            userAccount.IsActive = false;

            // Güncellemeyi veritabanına kaydediyoruz
            _context.UserAccounts.Update(userAccount);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
    public async Task<UserAccount> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await _context.UserAccounts.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }

    public async Task<UserAccount> GetByUserNameAsync(string username, CancellationToken cancellationToken)
    {
        return await _context.UserAccounts.FirstOrDefaultAsync(u => u.UserName == username, cancellationToken);
    }

    public async Task<IEnumerable<UserAccount>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.UserAccounts.ToListAsync(cancellationToken);
    }

    public async Task<UserAccount> GetUsersWithBranchesAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.UserAccounts
            .Include(u => u.UserBranches)
            .FirstOrDefaultAsync(u => u.UserId == id, cancellationToken);
    }
}

