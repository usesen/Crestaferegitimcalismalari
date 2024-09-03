using VelorusNet8.Application.DTOs.Menu;

namespace VelorusNet8.Application.Interface.Menus;

public interface IMenuService
{
    Task<MenuDto> GetByIdAsync(int menuId, CancellationToken cancellationToken);
    Task AddAsync(MenuDto menuDto, CancellationToken cancellationToken);
    Task UpdateAsync(MenuDto menuDto, CancellationToken cancellationToken);
    Task DeleteAsync(int menuId, CancellationToken cancellationToken);
    Task<MenuDto> GetByTitleAsync(string title, CancellationToken cancellationToken);
    Task<IEnumerable<MenuDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<MenuDto> GetMenuWithPermissionsAsync(int menuId, CancellationToken cancellationToken);
}
