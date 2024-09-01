namespace VelorusNet8.Domain.Entities.Aggregates.Identity.Interfaces;

public interface IUserRoleRepository 
{
    Task<UserRole> GetRoleByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<UserRole>> GetAllRolesAsync(CancellationToken cancellationToken);
    void Add(UserRole rolepermission);
    void Remove(UserRole rolepermission);
    void Update(UserRole rolepermission);
}
