using System.ComponentModel.DataAnnotations;
using VelorusNet8.Domain.Entities.Common;

namespace VelorusNet8.Domain.Entities.Aggregates.Menus;

public class Menu : EntityBase
{
    [Key]
    public int MenuId { get; set; }  // Menü öğesinin benzersiz kimliği

    public string Title { get; set; }  // Menü öğesinin başlığı

    public string Icon { get; set; }  // Menü öğesinin ikonu

    public string Url { get; set; }  // Menü öğesinin yönlendirileceği URL

    public int? ParentMenuId { get; set; }  // Eğer bu menü bir alt menü ise, üst menü kimliği
    public Menu ParentMenu { get; set; }  // Üst menü ile ilişki

    public ICollection<Menu> SubMenus { get; set; }  // Alt menülerin listesi

    public ICollection<MenuPermission> MenuPermissions { get; set; }  // Menü izinleri ile ilişki

    public Menu()
    {
        SubMenus = new HashSet<Menu>();
        MenuPermissions = new HashSet<MenuPermission>();
    }
}
