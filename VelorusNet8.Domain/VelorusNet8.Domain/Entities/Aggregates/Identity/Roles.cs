using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VelorusNet8.Domain.Entities.Aggregates.Identity;
 
public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Role ile UserRole arasındaki ilişki (Bir rol birçok UserRole'e sahip olabilir)
    public ICollection<UserRole> UserRoles { get; set; }

    // Role ile RolePermission arasındaki ilişki (Bir rol birçok izne sahip olabilir)
    public ICollection<RolePermission> RolePermissions { get; set; }
}