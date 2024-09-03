using Microsoft.EntityFrameworkCore;
using VelorusNet8.Application.Interface.Group;
using VelorusNet8.Domain.Entities.Aggregates.Groups;
using VelorusNet8.Infrastructure.Data;

namespace VelorusNet8.Infrastructure.Repositories;

public class UserAccountGroupRepository : IUserAccountGroupRepository
{
    private readonly AppDbContext _context;

    public UserAccountGroupRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<UserAccountGroup> GetByIdAsync(int userAccountGroupId, CancellationToken cancellationToken)
    {
        return await _context.UserAccountGroups
            .FirstOrDefaultAsync(uag => uag.UserAccountId == userAccountGroupId, cancellationToken);
    }

    public async Task AddAsync(UserAccountGroup userAccountGroup, CancellationToken cancellationToken)
    {
        await _context.UserAccountGroups.AddAsync(userAccountGroup, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int userAccountGroupId, CancellationToken cancellationToken)
    {
        var userAccountGroup = await _context.UserAccountGroups.FindAsync(new object[] { userAccountGroupId }, cancellationToken);
        if (userAccountGroup != null)
        {
            _context.UserAccountGroups.Remove(userAccountGroup);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task<IEnumerable<UserAccountGroup>> GetByUserIdAsync(int userId, CancellationToken cancellationToken)
    {
        return await _context.UserAccountGroups
            .Where(uag => uag.UserAccountId == userId)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<UserAccountGroup>> GetByGroupIdAsync(int groupId, CancellationToken cancellationToken)
    {
        return await _context.UserAccountGroups
            .Where(uag => uag.GroupId == groupId)
            .ToListAsync(cancellationToken);
    }

    public async Task RemoveByGroupIdAsync(int groupId, CancellationToken cancellationToken)
    {
        var userAccountGroups = await _context.UserAccountGroups
            .Where(uag => uag.GroupId == groupId)
            .ToListAsync(cancellationToken);

        if (userAccountGroups.Any())
        {
            _context.UserAccountGroups.RemoveRange(userAccountGroups);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
