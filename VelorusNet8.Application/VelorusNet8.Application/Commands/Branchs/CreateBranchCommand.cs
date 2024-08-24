using MediatR;

namespace VelorusNet8.Application.Commands.Branchs;

public class CreateBranchCommand : IRequest<int> // ID veya başarılı oluşturma sonucu döndürülür
{
    public string BranchCode { get; set; }
    public string BranchName { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public string Email { get; set; }
    public decimal CommissionRate { get; set; }
    public decimal CommissionAmount { get; set; }
    public decimal DefaultShrinkageRate { get; set; }
    public bool IsHeadOffice { get; set; }
    public bool IsSalesEnabled { get; set; }
    public bool IsAutomationIntegrationEnabled { get; set; }
}
