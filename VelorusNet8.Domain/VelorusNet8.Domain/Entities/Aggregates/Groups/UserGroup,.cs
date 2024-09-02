using System.ComponentModel.DataAnnotations;
using VelorusNet8.Domain.Entities.Aggregates.Menus;
using VelorusNet8.Domain.Entities.Common;

namespace VelorusNet8.Domain.Entities.Aggregates.Groups;

public class UserGroup : EntityBase
{
    [Key]
    public int Id { get; set; }  // Birincil anahtar

    public string Name { get; set; }  // Grubun adı

    // Group ile UserAccount arasındaki ilişki
    public ICollection<UserAccountGroup> UserAccountGroups { get; set; }

    // Group ile MenuPermissions arasındaki ilişki
    public ICollection<MenuPermission> MenuPermissions { get; set; }

    public UserGroup()
    {
        UserAccountGroups = new HashSet<UserAccountGroup>();
        MenuPermissions = new HashSet<MenuPermission>();
    }

}
