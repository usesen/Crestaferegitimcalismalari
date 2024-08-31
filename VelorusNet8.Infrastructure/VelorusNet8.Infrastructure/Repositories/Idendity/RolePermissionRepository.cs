using Microsoft.EntityFrameworkCore;
using VelorusNet8.Application.Interface.Identity;
using VelorusNet8.Domain.Entities.Aggregates.Identity;
using VelorusNet8.Infrastructure.Data;

namespace VelorusNet8.Infrastructure.Repositories.Idendity;

public class RolePermissionRepository : IRolePermissionRepository
{
    private readonly AppDbContext _context;

    public RolePermissionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<RolePermission> GetByIdAsync(int id)
    {
        return await _context.RolePermissions.FindAsync(id);
    }

    public async Task<IEnumerable<RolePermission>> GetAllAsync()
    {
        return await _context.RolePermissions.ToListAsync();
    }

    public void Add(RolePermission rolePermission)
    {
        _context.RolePermissions.Add(rolePermission);
    }

    public void Remove(RolePermission rolePermission)
    {
        _context.RolePermissions.Remove(rolePermission);
    }
}
