namespace VelorusNet8.Application.DTOs.Group;

public class UpdateUserGroupDto
{
    public int Id { get; set; }  // Güncellenen kullanıcı grubunun kimliği
    public string Name { get; set; }  // Kullanıcı grubunun adı
    public string Description { get; set; }  // Kullanıcı grubunun açıklaması
    public List<int> PermissionIds { get; set; }  // İlgili izinlerin kimlikleri

    public UpdateUserGroupDto()
    {
        PermissionIds = new List<int>();
    }
}
