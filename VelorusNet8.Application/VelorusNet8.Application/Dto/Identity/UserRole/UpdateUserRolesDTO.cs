using VelorusNet8.Application.Dto.Identity.Role;
using VelorusNet8.Application.Dto.User;
using VelorusNet8.Domain.Entities.Aggregates.Users;

namespace VelorusNet8.Application.Dto.Identity.UserRole;

public class UpdateUserRolesDTO
{
    public int UserId { get; set; }
    public UserAccountDto User { get; set; }

    public int RoleId { get; set; }
    public RoleDTO Role { get; set; }
}
