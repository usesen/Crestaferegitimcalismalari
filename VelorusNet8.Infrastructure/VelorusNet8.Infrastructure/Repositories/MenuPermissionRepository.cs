using Microsoft.EntityFrameworkCore;
using VelorusNet8.Application.Interface.Menus;
using VelorusNet8.Domain.Entities.Aggregates.Menus;
using VelorusNet8.Infrastructure.Data;

namespace VelorusNet8.Infrastructure.Repositories;

public class MenuPermissionRepository : IMenuPermissionRepository
{
    private readonly AppDbContext _context;

    public MenuPermissionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<MenuPermission> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.MenuPermissions.FindAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<MenuPermission>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.MenuPermissions.ToListAsync(cancellationToken);
    }

    public async Task AddAsync(MenuPermission menuPermission, CancellationToken cancellationToken)
    {
        await _context.MenuPermissions.AddAsync(menuPermission, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(MenuPermission menuPermission, CancellationToken cancellationToken)
    {
        _context.MenuPermissions.Update(menuPermission);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var menuPermission = await GetByIdAsync(id, cancellationToken);
        if (menuPermission != null)
        {
            _context.MenuPermissions.Remove(menuPermission);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }

    public Task<IEnumerable<MenuPermission>> GetByUserGroupIdAsync(int userGroupId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<MenuPermission> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

