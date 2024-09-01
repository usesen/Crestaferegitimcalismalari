using VelorusNet8.Application.Dto.Identity.Role;
using VelorusNet8.Application.Dto.Identity.RolePermission;
using VelorusNet8.Application.Dtos.Identity.RolePermission;
using VelorusNet8.Application.DTOs.Identity;
using VelorusNet8.Application.Interface.Service;
using VelorusNet8.Domain.Entities.Aggregates.Identity;
using VelorusNet8.Domain.Entities.Aggregates.Identity.Interfaces;
using VelorusNet8.Infrastructure.Interface;
using RolePermissionDTO = VelorusNet8.Application.DTOs.Identity.RolePermissionDTO;

namespace VelorusNet8.Application.Service.Identity;

public class RolePermissionService : IRolePermissionService
{
    private readonly IRolePermissionRepository _rolePermissionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RolePermissionService(IRolePermissionRepository rolePermissionRepository, IUnitOfWork unitOfWork)
    {
        _rolePermissionRepository = rolePermissionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<RolePermissionDTO> GetRolePermissionByIdAsync(int id, CancellationToken cancellationToken)
    {
        var rolePermission = await _rolePermissionRepository.GetRoleByIdAsync(id, cancellationToken);
        if (rolePermission == null) return null;

        var permission = rolePermission.Permission;
        var roles = rolePermission.Role;

        return new RolePermissionDTO
        {
            Id = rolePermission.Id,
            RoleId = rolePermission.RoleId,
            PermissionId = rolePermission.PermissionId,
            Name = permission?.Name,
            Roles = roles != null ? new List<RoleDTO>
            {
                new RoleDTO
                {
                    Id = roles.Id,
                    Name = roles.Name
                }
            } : new List<RoleDTO>()
        };
    }

    public async Task<IEnumerable<RolePermissionDTO>> GetAllRolePermissionsAsync(CancellationToken cancellationToken)
    {
        var rolePermissions = await _rolePermissionRepository.GetAllRolesAsync(cancellationToken);
        return rolePermissions.Select(rolePermission => new RolePermissionDTO
        {
            Id = rolePermission.Id,
            RoleId = rolePermission.RoleId,
            PermissionId = rolePermission.PermissionId
        }).ToList();
    }

    public async Task<int> CreateRolePermissionAsync(CreateRolePermissionDTO createRolePermissionDto, CancellationToken cancellationToken)
    {
        var rolePermission = new RolePermission
        {
            RoleId = createRolePermissionDto.RoleId,
            PermissionId = createRolePermissionDto.PermissionId
        };

        _rolePermissionRepository.Add(rolePermission);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return rolePermission.Id;
    }

    public async Task<bool> UpdateRolePermissionAsync(int id, UpdateRolePermissionDTO updateRolePermissionDto, CancellationToken cancellationToken)
    {
        var rolePermission = await _rolePermissionRepository.GetRoleByIdAsync(id, cancellationToken);
        if (rolePermission == null) return false;

        // DTO'daki doğru alanları kullanarak RolePermission'u güncelleyin
        rolePermission.RoleId = updateRolePermissionDto.RoleId;
        rolePermission.PermissionId = updateRolePermissionDto.PermissionId;

        _rolePermissionRepository.Update(rolePermission);
        await _unitOfWork.CompleteAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeleteRolePermissionAsync(int id, CancellationToken cancellationToken)
    {
        var rolePermission = await _rolePermissionRepository.GetRoleByIdAsync(id, cancellationToken);
        if (rolePermission == null) return false;

        _rolePermissionRepository.Remove(rolePermission);
        await _unitOfWork.CompleteAsync(cancellationToken);
        return true;
    }

 
}