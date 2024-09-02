using VelorusNet8.Application.DTOs.Identity.Role;

namespace VelorusNet8.Application.Dto.Identity.RolePermission;

public class CreateRolePermissionDTO
{
    public int Id { get; set; }
    public int RoleId { get; set; }
    public int PermissionId { get; set; }

    public string Name { get; set; } // Permission adını tutmak için
    public List<RoleDTO> Roles { get; set; } // Role'ların basit bir listesi
}
