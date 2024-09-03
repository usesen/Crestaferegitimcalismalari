using AutoMapper;
using VelorusNet8.Application.DTOs.Menu;
using VelorusNet8.Application.Interface.Menus;
using VelorusNet8.Domain.Entities.Aggregates.Menus;

namespace VelorusNet8.Application.Service;

public class MenuPermissionService : IMenuPermissionService
{
    private readonly IMenuPermissionRepository _menuPermissionRepository;
    private readonly IMapper _mapper;

    public MenuPermissionService(IMenuPermissionRepository menuPermissionRepository, IMapper mapper)
    {
        _menuPermissionRepository = menuPermissionRepository;
        _mapper = mapper;
    }

    public async Task<MenuPermissionDto> GetByIdAsync(int permissionId, CancellationToken cancellationToken)
    {
        var permission = await _menuPermissionRepository.GetByIdAsync(permissionId, cancellationToken);
        return _mapper.Map<MenuPermissionDto>(permission);
    }

    public async Task AddAsync(MenuPermissionDto menuPermissionDto, CancellationToken cancellationToken)
    {
        var permission = _mapper.Map<MenuPermission>(menuPermissionDto);
        await _menuPermissionRepository.AddAsync(permission, cancellationToken);
    }

    public async Task UpdateAsync(MenuPermissionDto menuPermissionDto, CancellationToken cancellationToken)
    {
        var permission = _mapper.Map<MenuPermission>(menuPermissionDto);
        await _menuPermissionRepository.UpdateAsync(permission, cancellationToken);
    }

    public async Task DeleteAsync(int permissionId, CancellationToken cancellationToken)
    {
        await _menuPermissionRepository.DeleteAsync(permissionId, cancellationToken);
    }

    public async Task<MenuPermissionDto> GetByTitleAsync(string title, CancellationToken cancellationToken)
    {
        var permission = await _menuPermissionRepository.GetByNameAsync(title, cancellationToken);
        return _mapper.Map<MenuPermissionDto>(permission);
    }

    public async Task<IEnumerable<MenuPermissionDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var permissions = await _menuPermissionRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<MenuPermissionDto>>(permissions);
    }

    public async Task<MenuPermissionDto> GetPermissionWithMenuAsync(int permissionId, CancellationToken cancellationToken)
    {
        var permission = await _menuPermissionRepository.GetByIdAsync(permissionId, cancellationToken);
        return _mapper.Map<MenuPermissionDto>(permission);
    }
}
