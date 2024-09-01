using Microsoft.EntityFrameworkCore;
using VelorusNet8.Domain.Entities.Aggregates.Identity;
using VelorusNet8.Domain.Entities.Aggregates.Identity.Interfaces;
using VelorusNet8.Infrastructure.Data;

namespace VelorusNet8.Infrastructure.Repositories.Idendity;

public class UserRolesRepository : IUserRolesRepository
{
    private readonly AppDbContext _context;

    public UserRolesRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(UserRole userRole)
    {
        _context.UserRoles.Add(userRole);
    }

    public async Task<IEnumerable<UserRole>> GetAllRolesAsync(CancellationToken cancellationToken)
    {
        return await _context.UserRoles
                                .Include(ur => ur.User)   // User ile ilişkiyi dahil ediyoruz
                                .Include(ur => ur.Role)   // Role ile ilişkiyi dahil ediyoruz
                                .ToListAsync(cancellationToken);
    }

    public async Task<UserRole> GetRoleByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.UserRoles
                                 .Include(ur => ur.User)   // User ile ilişkiyi dahil ediyoruz
                                 .Include(ur => ur.Role)   // Role ile ilişkiyi dahil ediyoruz
                                 .FirstOrDefaultAsync(ur => ur.Id == id, cancellationToken);
    }

    public void Remove(UserRole userRole)
    {
        _context.UserRoles.Remove(userRole);
    }

    public void Update(UserRole userRole)
    {
        _context.UserRoles.Update(userRole);
    }
}
