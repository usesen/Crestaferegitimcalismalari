using System.ComponentModel.DataAnnotations;
using VelorusNet8.Domain.Entities.Aggregates.Groups;
using VelorusNet8.Domain.Entities.Aggregates.Users;
using VelorusNet8.Domain.Entities.Common;

namespace VelorusNet8.Domain.Entities.Aggregates.Menus;

public class MenuPermission : EntityBase
{
    [Key]
    public int MenuPermissionId { get; set; }  // Menü izninin benzersiz kimliği

    public int MenuId { get; set; }  // İlişkili menü kimliği
    public Menu Menu { get; set; }  // Menü öğesi ile ilişki

    public int? UserAccountId { get; set; }  // Kullanıcıya özgü izinler için
    public UserAccount UserAccount { get; set; }  // Kullanıcı hesabı ile ilişki

    public int? GroupId { get; set; }  // Gruba özgü izinler için
    public UserGroup UserGroup { get; set; }  // Grup ile ilişki

    public bool CanView { get; set; }  // Görüntüleme izni
    public bool CanEdit { get; set; }  // Düzenleme izni
    public bool CanDelete { get; set; }  // Silme izni

    // Raporlama seçenekleri
    public bool CanExcel { get; set; }  // Excel raporu oluşturma izni
    public bool CanPdf { get; set; }  // PDF raporu oluşturma izni
    public bool CanWord { get; set; }  // Word raporu oluşturma izni

    public MenuPermission()
    {
    }

}
