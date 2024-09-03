using Microsoft.EntityFrameworkCore;
using VelorusNet8.Application.Interface.Group;
using VelorusNet8.Domain.Entities.Aggregates.Groups;
using VelorusNet8.Infrastructure.Data;

namespace VelorusNet8.Infrastructure.Repositories;

public class UserGroupRepository : IUserGroupRepository
{
    private readonly AppDbContext _context;

    public UserGroupRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<UserGroup> GetByIdAsync(int userGroupId, CancellationToken cancellationToken)
    {
        return await _context.UserGroups
            .FirstOrDefaultAsync(ug => ug.Id == userGroupId, cancellationToken);
    }

    public async Task AddAsync(UserGroup userGroup, CancellationToken cancellationToken)
    {
        await _context.UserGroups.AddAsync(userGroup, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(UserGroup userGroup, CancellationToken cancellationToken)
    {
        _context.UserGroups.Update(userGroup);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int userGroupId, CancellationToken cancellationToken)
    {
        var userGroup = await GetByIdAsync(userGroupId, cancellationToken);
        if (userGroup != null)
        {
            _context.UserGroups.Remove(userGroup);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task<UserGroup> GetByNameAsync(string groupName, CancellationToken cancellationToken)
    {
        return await _context.UserGroups
            .FirstOrDefaultAsync(ug => ug.Name.Equals(groupName, StringComparison.OrdinalIgnoreCase), cancellationToken);
    }

    public async Task<IEnumerable<UserGroup>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.UserGroups
            .ToListAsync(cancellationToken);
    }

    public async Task<UserGroup> GetUserGroupsWithPermissionsAsync(int userGroupId, CancellationToken cancellationToken)
    {
        return await _context.UserGroups
            .Include(ug => ug.MenuPermissions)
            .FirstOrDefaultAsync(ug => ug.Id == userGroupId, cancellationToken);
    }
  
}


