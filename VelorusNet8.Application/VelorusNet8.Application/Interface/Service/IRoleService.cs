using VelorusNet8.Application.DTOs.Identity.Role;

namespace VelorusNet8.Application.Interface.Service;

public interface IRoleService
{
    Task<RoleDTO> GetRoleByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<RoleDTO>> GetAllRolesAsync(CancellationToken cancellationToken);
    Task<int> CreateRoleAsync(CreateRoleDTO createRoleDto, CancellationToken cancellationToken);
    Task<bool> UpdateRoleAsync(int id, UpdateRoleDTO updateRoleDto, CancellationToken cancellationToken);
    Task<bool> DeleteRoleAsync(int id, CancellationToken cancellationToken);
}
