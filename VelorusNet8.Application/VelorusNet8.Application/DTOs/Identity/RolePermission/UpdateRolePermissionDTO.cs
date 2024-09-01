using VelorusNet8.Application.Dto.Identity.Role;
namespace VelorusNet8.Application.Dtos.Identity.RolePermission;

public class UpdateRolePermissionDTO
{
    public int Id { get; set; }  // RolePermission entity'sinin Id'si
    public int RoleId { get; set; }  // Role Id'si
    public int PermissionId { get; set; }  // Permission Id'si
    public string Name { get; set; }  // İsteğe bağlı olarak eklenen name alanı

    // İzin ile ilişkilendirilmiş rollerin basit bir listesi
    public List<RoleDTO> Roles { get; set; }
}
