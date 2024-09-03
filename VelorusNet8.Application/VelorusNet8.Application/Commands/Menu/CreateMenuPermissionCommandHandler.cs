using AutoMapper;
using MediatR;
using VelorusNet8.Application.Interface.Menus;
using VelorusNet8.Domain.Entities.Aggregates.Menus;

namespace VelorusNet8.Application.Commands.Menu;

public class CreateMenuPermissionCommandHandler : IRequestHandler<CreateMenuPermissionCommand, int>
{
    private readonly IMenuPermissionRepository _menuPermissionRepository;
    private readonly IMapper _mapper;

    public CreateMenuPermissionCommandHandler(IMenuPermissionRepository menuPermissionRepository, IMapper mapper)
    {
        _menuPermissionRepository = menuPermissionRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateMenuPermissionCommand request, CancellationToken cancellationToken)
    {
        var menuPermission = _mapper.Map<MenuPermission>(request);
        await _menuPermissionRepository.AddAsync(menuPermission, cancellationToken);
        return menuPermission.MenuId;
    }
}
