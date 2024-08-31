using VelorusNet8.Application.Dto.Identity;
using VelorusNet8.Application.Dto.Identity.Role;
using VelorusNet8.Application.Dto.Identity.UserRole;
using VelorusNet8.Domain.Entities.Aggregates.Identity;

namespace VelorusNet8.Application.Interface.Service;

public interface IRoleService
{
    Task<RoleDTO> GetRoleByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<RoleDTO>> GetAllRolesAsync(CancellationToken cancellationToken);
    Task<int> CreateRoleAsync(CreateRoleDTO createRoleDto, CancellationToken cancellationToken);
    Task<bool> UpdateRoleAsync(int id, UpdateUserRolesDTO updateRoleDto, CancellationToken cancellationToken);
    Task<bool> DeleteRoleAsync(int id, CancellationToken cancellationToken);
}
