using Microsoft.EntityFrameworkCore;
using VelorusNet8.Application.Interface.Group;
using VelorusNet8.Domain.Entities.Aggregates.Menus;
using VelorusNet8.Infrastructure.Data;

namespace VelorusNet8.Infrastructure.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly AppDbContext _context;

    public MenuRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Menu> GetByIdAsync(int menuId, CancellationToken cancellationToken)
    {
        return await _context.Menus
            .FirstOrDefaultAsync(m => m.MenuId == menuId, cancellationToken);
    }

    public async Task AddAsync(Menu menu, CancellationToken cancellationToken)
    {
        await _context.Menus.AddAsync(menu, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Menu menu, CancellationToken cancellationToken)
    {
        _context.Menus.Update(menu);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int menuId, CancellationToken cancellationToken)
    {
        var menu = await _context.Menus.FindAsync(new object[] { menuId }, cancellationToken);
        if (menu != null)
        {
            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task<Menu> GetByTitleAsync(string title, CancellationToken cancellationToken)
    {
        return await _context.Menus
            .FirstOrDefaultAsync(m => m.Title == title, cancellationToken);
    }

    public async Task<IEnumerable<Menu>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Menus.ToListAsync(cancellationToken);
    }

    public async Task<Menu> GetMenuWithPermissionsAsync(int menuId, CancellationToken cancellationToken)
    {
        return await _context.Menus
            .Include(m => m.MenuPermissions)
            .FirstOrDefaultAsync(m => m.MenuId == menuId, cancellationToken);
    }
}

