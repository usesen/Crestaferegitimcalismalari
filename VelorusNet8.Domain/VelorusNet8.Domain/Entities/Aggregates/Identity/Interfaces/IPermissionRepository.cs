
namespace VelorusNet8.Domain.Entities.Aggregates.Identity.Interfaces;
public interface IPermissionRepository
{
    Task<Permission> GetPermissionByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<Permission>> GetAllPermissionsAsync(CancellationToken cancellationToken);
    void Add(Permission permission);
    void Remove(Permission permission);
    void Update(Permission permission);
}