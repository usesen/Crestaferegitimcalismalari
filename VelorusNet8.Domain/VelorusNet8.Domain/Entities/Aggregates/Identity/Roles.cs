
using VelorusNet8.Domain.Entities.Common;

namespace VelorusNet8.Domain.Entities.Aggregates.Identity;
 
public class Role :EntityBase
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Role ile UserRole arasındaki ilişki (Bir rol birçok UserRole'e sahip olabilir)
    public ICollection<UserRole> UserRoles { get; set; }

    // Role ile RolePermission arasındaki ilişki (Bir rol birçok izne sahip olabilir)
    public ICollection<RolePermission> RolePermissions { get; set; }
}