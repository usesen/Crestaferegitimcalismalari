using VelorusNet8.Application.Dto.Identity.Permission;
using VelorusNet8.Application.Dto.Identity.Permission.PermissionDTO;
using VelorusNet8.Application.DTOs.Identity.Permission;
using VelorusNet8.Domain.Entities.Aggregates.Identity;

namespace VelorusNet8.Application.Interface.Service;


public interface IPermissionService
{
   Task<PermissionDTO> GetPermissionByIdAsync(int id, CancellationToken cancellationToken);
   Task<IEnumerable<PermissionDTO>> GetAllPermissionsAsync(CancellationToken cancellationToken);
   Task<int> CreatePermissionAsync(CreatePermissionDTO createPermissionDto, CancellationToken cancellationToken);
   Task<bool> UpdatePermissionAsync(int id, UpdatePermissionDTO updatePermissionDto, CancellationToken cancellationToken);
   Task<bool> DeletePermissionAsync(int id, CancellationToken cancellationToken);
}
