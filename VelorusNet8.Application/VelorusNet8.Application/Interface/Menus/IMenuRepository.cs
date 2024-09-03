using VelorusNet8.Domain.Entities.Aggregates.Menus;

namespace VelorusNet8.Application.Interface.Group;

public interface IMenuRepository
{
    Task<Menu> GetByIdAsync(int menuId, CancellationToken cancellationToken);
    Task AddAsync(Menu menu, CancellationToken cancellationToken);
    Task UpdateAsync(Menu menu, CancellationToken cancellationToken);
    Task DeleteAsync(int menuId, CancellationToken cancellationToken);
    Task<Menu> GetByTitleAsync(string title, CancellationToken cancellationToken);
    Task<IEnumerable<Menu>> GetAllAsync(CancellationToken cancellationToken);
    Task<Menu> GetMenuWithPermissionsAsync(int menuId, CancellationToken cancellationToken);
}
