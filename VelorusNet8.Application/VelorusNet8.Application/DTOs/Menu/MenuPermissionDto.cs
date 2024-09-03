namespace VelorusNet8.Application.DTOs.Menu;

public class MenuPermissionDto
{
    public int PermissionId { get; set; }  // İzin kimliği

    public string PermissionName { get; set; }  // İzin adı

    public string Description { get; set; }  // İznin açıklaması

    public int MenuId { get; set; }  // İznin bağlı olduğu Menü kimliği

    public MenuDto Menu { get; set; }  // İzin ile ilişkili Menü

    public MenuPermissionDto()
    {
        // Varsayılan constructor
    }
}
