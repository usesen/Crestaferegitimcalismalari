using VelorusNet8.Domain.Entities.Aggregates.Users;
using VelorusNet8.Domain.Repositories;
using VelorusNet8.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace VelorusNet8.Infrastructure.Repositories;


    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly AppDbContext _context;

        public UserAccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(UserAccount entity, CancellationToken cancellationToken)
        {
            await _context.UserAccounts.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

    public async Task<UserAccount> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.UserAccounts
            .FirstOrDefaultAsync(u => u.UserId == id, cancellationToken);
    }

    public async Task<IEnumerable<UserAccount>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.UserAccounts.ToListAsync(cancellationToken);
        }

        public async Task UpdateAsync(UserAccount entity, CancellationToken cancellationToken)
        {
            _context.UserAccounts.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(UserAccount entity, CancellationToken cancellationToken)
        {
            _context.UserAccounts.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<UserAccount> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await _context.UserAccounts
                .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
        }

        public async Task<UserAccount> GetByUserNameAsync(string username, CancellationToken cancellationToken)
        {
            return await _context.UserAccounts
                .FirstOrDefaultAsync(u => u.UserName == username, cancellationToken);
        }
    }

