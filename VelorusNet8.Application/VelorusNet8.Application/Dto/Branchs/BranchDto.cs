namespace VelorusNet8.Application.Dto.Branchs;

public class BranchDto
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
    public bool IsActive { get; set; } 
}

