
using VelorusNet8.Application.Dtos.Identity.UserRole;
using VelorusNet8.Application.DTOs.Identity.UserRole;
using VelorusNet8.Application.Interface.Service;
using VelorusNet8.Domain.Entities.Aggregates.Identity;
using VelorusNet8.Domain.Entities.Aggregates.Identity.Interfaces;
using VelorusNet8.Infrastructure.Interface;

namespace VelorusNet8.Application.Service.Identity;

public class UserRoleService : IUserRoleService
{
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserRoleService(IUserRoleRepository userRoleRepository, IUnitOfWork unitOfWork)
    {
        _userRoleRepository = userRoleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UserRoleDTO> GetUserRoleByIdAsync(int id, CancellationToken cancellationToken)
    {
        var userRole = await _userRoleRepository.GetRoleByIdAsync(id, cancellationToken);
        if (userRole == null) return null;

        return new UserRoleDTO
        {
            Id = userRole.Id,
            UserId = userRole.UserId,
            RoleId = userRole.RoleId
        };
    }

    public async Task<IEnumerable<UserRoleDTO>> GetAllUserRolesAsync(CancellationToken cancellationToken)
    {
        var userRoles = await _userRoleRepository.GetAllRolesAsync(cancellationToken);
        return userRoles.Select(userRole => new UserRoleDTO
        {
            Id = userRole.Id,
            UserId = userRole.UserId,
            RoleId = userRole.RoleId
        }).ToList();
    }

    public async Task<int> CreateUserRoleAsync(CreateUserRoleDTO createUserRoleDto, CancellationToken cancellationToken)
    {
        var userRole = new UserRole
        {
            UserId = createUserRoleDto.UserId,
            RoleId = createUserRoleDto.RoleId
        };

        _userRoleRepository.Add(userRole);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return userRole.Id;
    }

    public async Task<bool> UpdateUserRoleAsync(int id, UpdateUserRoleDTO updateUserRoleDto, CancellationToken cancellationToken)
    {
        var userRole = await _userRoleRepository.GetRoleByIdAsync(id, cancellationToken);
        if (userRole == null) return false;

        userRole.UserId = updateUserRoleDto.UserId;
        userRole.RoleId = updateUserRoleDto.RoleId;

        _userRoleRepository.Update(userRole);
        await _unitOfWork.CompleteAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeleteUserRoleAsync(int id, CancellationToken cancellationToken)
    {
        var userRole = await _userRoleRepository.GetRoleByIdAsync(id, cancellationToken);
        if (userRole == null) return false;

        _userRoleRepository.Remove(userRole);
        await _unitOfWork.CompleteAsync(cancellationToken);
        return true;
    }
}

