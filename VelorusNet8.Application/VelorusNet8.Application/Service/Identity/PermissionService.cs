using VelorusNet8.Application.Dto.Identity;
using VelorusNet8.Application.Dto.Identity.Role;
using VelorusNet8.Application.Dto.Identity.UserRole;
using VelorusNet8.Application.Interface.Service;
using VelorusNet8.Infrastructure.Interface;

namespace VelorusNet8.Application.Service.Identity;

public class PermissionService : IRoleService
{
    private readonly IUnitOfWork _unitWork;

    public PermissionService(IUnitOfWork unitWork)
    {
        _unitWork = unitWork;
    }

    public Task<int> CreateRoleAsync(CreateRoleDTO createRoleDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteRoleAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<RoleDTO>> GetAllRolesAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<RoleDTO> GetRoleByIdAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateRoleAsync(int id, UpdateUserRolesDTO updateRoleDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
