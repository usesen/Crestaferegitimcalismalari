namespace VelorusNet8.Domain.Entities.Aggregates.Identity.Interfaces;

public interface IUserRoleRepository 
{
    Task<UserRole> GetRoleByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<UserRole>> GetAllRolesAsync(CancellationToken cancellationToken);
    void Add(UserRole userRole);
    void Remove(UserRole userRole);
    void Update(UserRole userRole);
}
