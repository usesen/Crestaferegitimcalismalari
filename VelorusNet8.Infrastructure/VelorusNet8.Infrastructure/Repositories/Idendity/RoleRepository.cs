using Microsoft.EntityFrameworkCore;
using VelorusNet8.Application.Interface.Identity;
using VelorusNet8.Domain.Entities.Aggregates.Identity;
using VelorusNet8.Infrastructure.Data;

namespace VelorusNet8.Infrastructure.Repositories.Idendity;

public class RoleRepository : IRoleRepository
{
    private readonly AppDbContext _context;

    public RoleRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Role> GetRoleByIdAsync(int id)
    {
        return await _context.Roles.FindAsync(id);
    }

    public async Task<IEnumerable<Role>> GetAllRolesAsync()
    {
        return await _context.Roles.ToListAsync();
    }

    public void AddRole(Role role)
    {
        _context.Roles.Add(role);
    }

    public void RemoveRole(Role role)
    {
        _context.Roles.Remove(role);
    }
}