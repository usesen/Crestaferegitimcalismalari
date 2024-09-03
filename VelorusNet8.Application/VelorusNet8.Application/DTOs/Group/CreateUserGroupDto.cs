namespace VelorusNet8.Application.DTOs.Group;

public class CreateUserGroupDto
{
    public string Name { get; set; }  // Kullanıcı grubunun adı
    public string Description { get; set; }  // Kullanıcı grubunun açıklaması
    public ICollection<int> PermissionIds { get; set; }  // İlgili izinlerin kimlikleri

    public CreateUserGroupDto()
    {
        PermissionIds = new List<int>();
    }
}
