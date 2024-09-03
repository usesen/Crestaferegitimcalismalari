using MediatR;

namespace VelorusNet8.Application.Commands.Menu;


public class UpdateMenuPermissionCommand : IRequest<Unit>
{
    public int MenuPermissionId { get; set; }  // Benzersiz kimlik
    public int MenuId { get; set; }  // İlişkili menü kimliği
    public int? UserAccountId { get; set; }  // Kullanıcıya özgü izinler için
    public int? GroupId { get; set; }  // Gruba özgü izinler için
    public bool CanView { get; set; }  // Görüntüleme izni
    public bool CanEdit { get; set; }  // Düzenleme izni
    public bool CanDelete { get; set; }  // Silme izni
    public bool CanExcel { get; set; }  // Excel raporu oluşturma izni
    public bool CanPdf { get; set; }  // PDF raporu oluşturma izni
    public bool CanWord { get; set; }  // Word raporu oluşturma izni
}