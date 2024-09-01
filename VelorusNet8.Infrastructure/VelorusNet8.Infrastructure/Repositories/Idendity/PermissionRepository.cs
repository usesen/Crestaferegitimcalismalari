

using Microsoft.EntityFrameworkCore;
using VelorusNet8.Domain.Entities.Aggregates.Identity;
using VelorusNet8.Domain.Entities.Aggregates.Identity.Interfaces;
using VelorusNet8.Infrastructure.Data;

namespace VelorusNet8.Infrastructure.Repositories.Idendity;

public class PermissionRepository : IPermissionRepository
{
    private readonly AppDbContext _context;

    public PermissionRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(Permission permission)
    {
        _context.Permissions.Add(permission);
    }

    public async Task<Permission> GetPermissionByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Permissions
                             .Include(p => p.RolePermissions) // İlgili RolePermissions'ı dahil ediyoruz
                             .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Permission>> GetAllPermissionsAsync(CancellationToken cancellationToken)
    {
        return await _context.Permissions
                             .Include(p => p.RolePermissions) // İlgili RolePermissions'ı dahil ediyoruz
                             .ToListAsync(cancellationToken);
    }

    public void Remove(Permission permission)
    {
        _context.Permissions.Remove(permission);
    }

    public void Update(Permission permission)
    {
        _context.Permissions.Update(permission);
    }


}
