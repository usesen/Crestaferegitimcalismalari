using VelorusNet8.Domain.Entities.Aggregates.Menus;

namespace VelorusNet8.Application.Interface.Menus;

public interface IMenuPermissionRepository
{
    // İlgili metodlar GetPermissionWithMenuAsync
    Task<MenuPermission> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<MenuPermission>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(MenuPermission menuPermission, CancellationToken cancellationToken);
    Task UpdateAsync(MenuPermission menuPermission, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
    // Yeni metodlar
    Task<IEnumerable<MenuPermission>> GetByUserGroupIdAsync(int userGroupId, CancellationToken cancellationToken);
    Task<MenuPermission> GetByNameAsync(string name, CancellationToken cancellationToken);
}
