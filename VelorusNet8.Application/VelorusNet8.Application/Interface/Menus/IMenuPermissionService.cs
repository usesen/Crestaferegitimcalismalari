using VelorusNet8.Application.DTOs.Menu;

namespace VelorusNet8.Application.Interface.Menus;

public interface IMenuPermissionService
{
    Task<MenuPermissionDto> GetByIdAsync(int permissionId, CancellationToken cancellationToken);
    Task AddAsync(MenuPermissionDto menuPermissionDto, CancellationToken cancellationToken);
    Task UpdateAsync(MenuPermissionDto menuPermissionDto, CancellationToken cancellationToken);
    Task DeleteAsync(int permissionId, CancellationToken cancellationToken);
    Task<MenuPermissionDto> GetByTitleAsync(string title, CancellationToken cancellationToken);
    Task<IEnumerable<MenuPermissionDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<MenuPermissionDto> GetPermissionWithMenuAsync(int permissionId, CancellationToken cancellationToken);
}

