using VelorusNet8.Application.Dto.Identity.RolePermission;
using VelorusNet8.Application.Dtos.Identity.RolePermission;
using VelorusNet8.Application.DTOs.Identity;


namespace VelorusNet8.Application.Interface.Service;

public interface IRolePermissionService
{
    Task<RolePermissionDTO> GetRolePermissionByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<RolePermissionDTO>> GetAllRolePermissionsAsync(CancellationToken cancellationToken);
    Task<int> CreateRolePermissionAsync(CreateRolePermissionDTO createRolePermissionDto, CancellationToken cancellationToken);
    Task<bool> UpdateRolePermissionAsync(int id, UpdateRolePermissionDTO updateRolePermissionDto, CancellationToken cancellationToken);
    Task<bool> DeleteRolePermissionAsync(int id, CancellationToken cancellationToken);

}
