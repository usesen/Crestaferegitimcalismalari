using VelorusNet8.Domain.Entities.Aggregates.Identity;

namespace VelorusNet8.Application.Interface.Service;

public interface IPermissionService
{
    Task<Permission> GetPermissionByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<Permission>> GetAllPermissionsAsync(CancellationToken cancellationToken);
    void AddPermission(Permission permission);
    void RemovePermission(Permission permission);
}