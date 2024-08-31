using VelorusNet8.Application.Dto.Identity.Role;
using VelorusNet8.Application.Dto.User;


namespace VelorusNet8.Application.Dto.Identity.UserRole;

public class UserRolesDTO
{
    public int UserId { get; set; }
    public UserAccountDto User { get; set; }

    public int RoleId { get; set; }
    public RoleDTO Role { get; set; }
}
