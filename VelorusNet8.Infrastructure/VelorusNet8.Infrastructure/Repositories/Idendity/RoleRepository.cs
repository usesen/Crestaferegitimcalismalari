using Microsoft.EntityFrameworkCore;
using VelorusNet8.Domain.Entities.Aggregates.Identity;
using VelorusNet8.Domain.Entities.Aggregates.Identity.Interfaces;
using VelorusNet8.Infrastructure.Data;

namespace VelorusNet8.Infrastructure.Repositories.Idendity;

public class RoleRepository : IRoleRepository
{
    private readonly AppDbContext _context;

    public RoleRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Role> GetRoleByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Roles
                             .Include(r => r.UserRoles)          // UserRoles ile ilişkiyi dahil ediyoruz
                             .Include(r => r.RolePermissions)    // RolePermissions ile ilişkiyi dahil ediyoruz
                             .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Role>> GetAllRolesAsync(CancellationToken cancellationToken)
    {
        return await _context.Roles
                             .Include(r => r.UserRoles)          // UserRoles ile ilişkiyi dahil ediyoruz
                             .Include(r => r.RolePermissions)    // RolePermissions ile ilişkiyi dahil ediyoruz
                             .ToListAsync(cancellationToken);
    }

    public void Add(Role role)
    {
        _context.Roles.Add(role);
    }

    public void Remove(Role role)
    {
        _context.Roles.Remove(role);
    }

    public void Update(Role role)
    {
        _context.Roles.Update(role);
    }
}