namespace VelorusNet8.Domain.Entities.Aggregates.Identity.Interfaces;

public interface IRoleRepository
{
    Task<Role> GetRoleByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<Role>> GetAllRolesAsync(CancellationToken cancellationToken);
    void Add(Role role);
    void Remove(Role role);
    void Update(Role role);
}