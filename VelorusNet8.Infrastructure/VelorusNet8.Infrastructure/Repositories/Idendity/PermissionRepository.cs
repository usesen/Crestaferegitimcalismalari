using Microsoft.EntityFrameworkCore;
using VelorusNet8.Application.Interface.Identity;
using VelorusNet8.Domain.Entities.Aggregates.Identity;
using VelorusNet8.Infrastructure.Data;

namespace VelorusNet8.Infrastructure.Repositories.Idendity;

public class PermissionRepository : IPermissionRepository
{
    private readonly AppDbContext _context;

    public PermissionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Permission> GetPermissionByIdAsync(int id)
    {
        return await _context.Permissions.FindAsync(id);
    }

    public async Task<IEnumerable<Permission>> GetAllPermissionsAsync()
    {
        return await _context.Permissions.ToListAsync();
    }

    public void AddPermission(Permission permission)
    {
        _context.Permissions.Add(permission);
    }

    public void RemovePermission(Permission permission)
    {
        _context.Permissions.Remove(permission);
    }
}