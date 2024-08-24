namespace VelorusNet8.Domain.Entities.Aggregates.Branchs;

public class BranchEntity
{
    public int Id { get; set; }
    public string BranchCode { get; set; }  // Şube Kodu
    public string BranchName { get; set; }  // Şube Adı
    public string Address { get; set; }  // Adres
    public string Phone { get; set; }  // Telefon
    public string Fax { get; set; }  // Faks
    public string Email { get; set; }  // E-Posta
    public decimal CommissionRate { get; set; }  // Prim Oranı
    public decimal CommissionAmount { get; set; }  // Prim Tutarı
    public decimal DefaultShrinkageRate { get; set; }  // Varsayılan Fire Oranı
    public bool IsHeadOffice { get; set; }  // Merkez
    public bool IsSalesEnabled { get; set; }  // Satış
    public bool IsAutomationIntegrationEnabled { get; set; }  // Otomasyon Entegrasyon
    public bool IsActive { get; set; } = true; // aktif pasif olayları


    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        var other = (BranchEntity)obj;
        return BranchCode == other.BranchCode &&
               BranchName == other.BranchName &&
               Address == other.Address &&
               Phone == other.Phone &&
               Fax == other.Fax &&
               Email == other.Email &&
               CommissionRate == other.CommissionRate &&
               CommissionAmount == other.CommissionAmount &&
               DefaultShrinkageRate == other.DefaultShrinkageRate &&
               IsHeadOffice == other.IsHeadOffice &&
               IsSalesEnabled == other.IsSalesEnabled &&
               IsAutomationIntegrationEnabled == other.IsAutomationIntegrationEnabled;
    }

    public override int GetHashCode()
    {
        // İlk grubu hashleyelim
        int hash1 = HashCode.Combine(BranchCode, BranchName, Address, Phone, Fax, Email);

        // İkinci grubu hashleyelim
        int hash2 = HashCode.Combine(CommissionRate, CommissionAmount, DefaultShrinkageRate);

        // Üçüncü grubu hashleyelim
        int hash3 = HashCode.Combine(IsHeadOffice, IsSalesEnabled, IsAutomationIntegrationEnabled);

        // Son olarak, bu üç hash grubunu birleştirerek final hash'i elde edelim
        return HashCode.Combine(hash1, hash2, hash3);
    }

}