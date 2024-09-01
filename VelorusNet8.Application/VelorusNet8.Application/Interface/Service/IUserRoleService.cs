using VelorusNet8.Application.Dtos.Identity.UserRole;



using VelorusNet8.Application.DTOs.Identity.UserRole;

namespace VelorusNet8.Application.Interface.Service;

public interface IUserRoleService
{
    Task<UserRoleDTO> GetUserRoleByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<UserRoleDTO>> GetAllUserRolesAsync(CancellationToken cancellationToken);
    Task<int> CreateUserRoleAsync(CreateUserRoleDTO createUserRoleDto, CancellationToken cancellationToken);
    Task<bool> UpdateUserRoleAsync(int id, UpdateUserRoleDTO updateUserRoleDto, CancellationToken cancellationToken);
    Task<bool> DeleteUserRoleAsync(int id, CancellationToken cancellationToken);
}

 