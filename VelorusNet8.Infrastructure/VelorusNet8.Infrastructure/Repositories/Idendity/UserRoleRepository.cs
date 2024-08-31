using Microsoft.EntityFrameworkCore;
using VelorusNet8.Application.Interface.Identity;
using VelorusNet8.Domain.Entities.Aggregates.Identity;
using VelorusNet8.Infrastructure.Data;

namespace VelorusNet8.Infrastructure.Repositories.Idendity;

public class UserRoleRepository : IUserRoleRepository
{
    private readonly AppDbContext _context;

    public UserRoleRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<UserRole> GetByIdAsync(int id)
    {
        return await _context.UserRoles.FindAsync(id);
    }

    public async Task<IEnumerable<UserRole>> GetAllAsync()
    {
        return await _context.UserRoles.ToListAsync();
    }

    public void Add(UserRole userRole)
    {
        _context.UserRoles.Add(userRole);
    }

    public void Remove(UserRole userRole)
    {
        _context.UserRoles.Remove(userRole);
    }
}
