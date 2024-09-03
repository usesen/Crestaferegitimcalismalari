using AutoMapper;
using VelorusNet8.Application.DTOs.Menu;
using VelorusNet8.Application.Interface.Group;
using VelorusNet8.Application.Interface.Menus;
using VelorusNet8.Domain.Entities.Aggregates.Menus;

namespace VelorusNet8.Application.Service;

public class MenuService : IMenuService
{
    private readonly IMenuRepository _menuRepository;
    private readonly IMapper _mapper;

    public MenuService(IMenuRepository menuRepository, IMapper mapper)
    {
        _menuRepository = menuRepository;
        _mapper = mapper;
    }

    public async Task<MenuDto> GetByIdAsync(int menuId, CancellationToken cancellationToken)
    {
        var menu = await _menuRepository.GetByIdAsync(menuId, cancellationToken);
        return _mapper.Map<MenuDto>(menu);
    }

    public async Task AddAsync(MenuDto menuDto, CancellationToken cancellationToken)
    {
        var menu = _mapper.Map<Menu>(menuDto);
        await _menuRepository.AddAsync(menu, cancellationToken);
    }

    public async Task UpdateAsync(MenuDto menuDto, CancellationToken cancellationToken)
    {
        var menu = _mapper.Map<Menu>(menuDto);
        await _menuRepository.UpdateAsync(menu, cancellationToken);
    }

    public async Task DeleteAsync(int menuId, CancellationToken cancellationToken)
    {
        await _menuRepository.DeleteAsync(menuId, cancellationToken);
    }

    public async Task<MenuDto> GetByTitleAsync(string title, CancellationToken cancellationToken)
    {
        var menu = await _menuRepository.GetByTitleAsync(title, cancellationToken);
        return _mapper.Map<MenuDto>(menu);
    }

    public async Task<IEnumerable<MenuDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var menus = await _menuRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<MenuDto>>(menus);
    }

    public async Task<MenuDto> GetMenuWithPermissionsAsync(int menuId, CancellationToken cancellationToken)
    {
        var menu = await _menuRepository.GetMenuWithPermissionsAsync(menuId, cancellationToken);
        return _mapper.Map<MenuDto>(menu);
    }
}
