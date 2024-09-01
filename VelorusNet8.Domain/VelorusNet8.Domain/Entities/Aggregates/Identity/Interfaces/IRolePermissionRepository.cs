namespace VelorusNet8.Domain.Entities.Aggregates.Identity.Interfaces;

public interface IRolePermissionRepository
{
    Task<RolePermission> GetRoleByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<RolePermission>> GetAllRolesAsync(CancellationToken cancellationToken);
    void Add(RolePermission rolepermission);
    void Remove(RolePermission rolepermission);
    void Update(RolePermission rolepermission);
}
