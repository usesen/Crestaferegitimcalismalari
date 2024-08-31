using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VelorusNet8.Domain.Entities.Aggregates.Identity;

public class Permission
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Permission ile RolePermission arasındaki ilişki (Bir izin birçok role atanabilir)
    public ICollection<RolePermission> RolePermissions { get; set; }
}