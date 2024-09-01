
using Microsoft.EntityFrameworkCore;
using VelorusNet8.Domain.Entities.Aggregates.Identity;
using VelorusNet8.Domain.Entities.Aggregates.Identity.Interfaces;
using VelorusNet8.Infrastructure.Data;

namespace VelorusNet8.Infrastructure.Repositories.Idendity;

public class RolePermissionRepository : IRolePermissionRepository
{
    private readonly AppDbContext _context;

    public RolePermissionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<RolePermission> GetRoleByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.RolePermissions
                             .Include(rp => rp.Role)          // Role ile ilişkiyi dahil ediyoruz
                             .Include(rp => rp.Permission)    // Permission ile ilişkiyi dahil ediyoruz
                             .FirstOrDefaultAsync(rp => rp.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<RolePermission>> GetAllRolesAsync(CancellationToken cancellationToken)
    {
        return await _context.RolePermissions
                             .Include(rp => rp.Role)          // Role ile ilişkiyi dahil ediyoruz
                             .Include(rp => rp.Permission)    // Permission ile ilişkiyi dahil ediyoruz
                             .ToListAsync(cancellationToken);
    }

    public void Add(RolePermission rolePermission)
    {
        _context.RolePermissions.Add(rolePermission);
    }

    public void Remove(RolePermission rolePermission)
    {
        _context.RolePermissions.Remove(rolePermission);
    }

    public void Update(RolePermission rolePermission)
    {
        _context.RolePermissions.Update(rolePermission);
    }
}