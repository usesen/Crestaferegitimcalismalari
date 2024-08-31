namespace VelorusNet8.Application.Dto.Identity.Role;

public class RolePermissionDTO
{
    public int Id { get; set; }
    public string Name { get; set; }

    // İzin ile ilişkilendirilmiş rollerin basit bir listesi
    public List<RoleDTO> Roles { get; set; }
}
