using VelorusNet8.Application.Dto.Identity.Permission.PermissionDTO;
using VelorusNet8.Application.DTOs.Identity.Permission;
using VelorusNet8.Application.Interface.Service;
using VelorusNet8.Domain.Entities.Aggregates.Identity;
using VelorusNet8.Domain.Entities.Aggregates.Identity.Interfaces;
using VelorusNet8.Infrastructure.Interface;

namespace VelorusNet8.Application.Service.Identity;

public class PermissionService : IPermissionService
{
    private readonly IPermissionRepository _permissionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PermissionService(IPermissionRepository permissionRepository, IUnitOfWork unitOfWork)
    {
        _permissionRepository = permissionRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<PermissionDTO> GetPermissionByIdAsync(int id, CancellationToken cancellationToken)
    {
        var permission = await _permissionRepository.GetPermissionByIdAsync(id, cancellationToken);
        if (permission == null) return null;

        return new PermissionDTO
        {
            Id = permission.Id,
            Name = permission.Name
        };
    }

    public async Task<IEnumerable<PermissionDTO>> GetAllPermissionsAsync(CancellationToken cancellationToken)
    {
        var permissions = await _permissionRepository.GetAllPermissionsAsync(cancellationToken);
        return permissions.Select(permission => new PermissionDTO
        {
            Id = permission.Id,
            Name = permission.Name
        }).ToList();
    }

    public async Task<int> CreatePermissionAsync(CreatePermissionDTO createPermissionDto, CancellationToken cancellationToken)
    {
        var permission = new Permission
        {
            Name = createPermissionDto.Name,
        };

        _permissionRepository.Add(permission);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return permission.Id;
    }

    public async Task<bool> UpdatePermissionAsync(int id, UpdatePermissionDTO updatePermissionDto, CancellationToken cancellationToken)
    {
        var permission = await _permissionRepository.GetPermissionByIdAsync(id, cancellationToken);
        if (permission == null) return false;

        permission.Name = updatePermissionDto.Name;

        _permissionRepository.Update(permission);
        await _unitOfWork.CompleteAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeletePermissionAsync(int id, CancellationToken cancellationToken)
    {
        var permission = await _permissionRepository.GetPermissionByIdAsync(id, cancellationToken);
        if (permission == null) return false;

        _permissionRepository.Remove(permission);
        await _unitOfWork.CompleteAsync(cancellationToken);
        return true;
    }
 
}