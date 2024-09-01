using VelorusNet8.Application.DTOs.Identity.Role;
using VelorusNet8.Application.Interface.Service;
using VelorusNet8.Domain.Entities.Aggregates.Identity;
using VelorusNet8.Domain.Entities.Aggregates.Identity.Interfaces;
using VelorusNet8.Infrastructure.Interface;

namespace VelorusNet8.Application.Service.Identity;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RoleService(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
    {
        _roleRepository = roleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<RoleDTO> GetRoleByIdAsync(int id, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetRoleByIdAsync(id, cancellationToken);
        if (role == null) return null;

        return new RoleDTO
        {
            Id = role.Id,
            Name = role.Name
        };
    }

    public async Task<IEnumerable<RoleDTO>> GetAllRolesAsync(CancellationToken cancellationToken)
    {
        var roles = await _roleRepository.GetAllRolesAsync(cancellationToken);
        return roles.Select(role => new RoleDTO
        {
            Id = role.Id,
            Name = role.Name
        }).ToList();
    }

    public async Task<int> CreateRoleAsync(CreateRoleDTO createRoleDto, CancellationToken cancellationToken)
    {
        var role = new Role
        {
            Name = createRoleDto.Name
        };

        _roleRepository.Add(role);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return role.Id;
    }

    public async Task<bool> UpdateRoleAsync(int id, UpdateRoleDTO updateRoleDto, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetRoleByIdAsync(id, cancellationToken);
        if (role == null) return false;

        role.Name = updateRoleDto.Name;

        _roleRepository.Update(role);
        await _unitOfWork.CompleteAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeleteRoleAsync(int id, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetRoleByIdAsync(id, cancellationToken);
        if (role == null) return false;

        _roleRepository.Remove(role);
        await _unitOfWork.CompleteAsync(cancellationToken);
        return true;
    }
}
