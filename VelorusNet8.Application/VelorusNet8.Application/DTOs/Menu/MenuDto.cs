namespace VelorusNet8.Application.DTOs.Menu;

public class MenuDto
{
    public int MenuId { get; set; }  // Menü öğesinin benzersiz kimliği

    public string Title { get; set; }  // Menü öğesinin başlığı

    public string Icon { get; set; }  // Menü öğesinin ikonu

    public string Url { get; set; }  // Menü öğesinin yönlendirileceği URL

    public int? ParentMenuId { get; set; }  // Eğer bu menü bir alt menü ise, üst menü kimliği

    public List<MenuDto> SubMenus { get; set; }  // Alt menülerin listesi

    public List<MenuPermissionDto> MenuPermissions { get; set; }  // Menü izinleri ile ilişki

    public MenuDto()
    {
        SubMenus = new List<MenuDto>();
        MenuPermissions = new List<MenuPermissionDto>();
    }
}

