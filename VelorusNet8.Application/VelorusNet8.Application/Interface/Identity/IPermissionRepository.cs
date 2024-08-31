using VelorusNet8.Domain.Entities.Aggregates.Identity;

namespace VelorusNet8.Application.Interface.Identity;

public interface IPermissionRepository
{
    Task<Permission> GetPermissionByIdAsync(int id);
    Task<IEnumerable<Permission>> GetAllPermissionsAsync();
    void AddPermission(Permission permission);
    void RemovePermission(Permission permission);
}