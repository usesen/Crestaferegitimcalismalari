using VelorusNet8.Domain.Entities.Aggregates.Identity;

namespace VelorusNet8.Application.Interface.Identity;

public interface IRoleRepository
{
    Task<Role> GetRoleByIdAsync(int id);
    Task<IEnumerable<Role>> GetAllRolesAsync();
    void AddRole(Role role);
    void RemoveRole(Role role);
}
