using VelorusNet8.Domain.Entities.Aggregates.Business.ValueOnject;
using VelorusNet8.Domain.Entities.Aggregates.Users;
using VelorusNet8.Domain.Entities.Common;
using VelorusNet8.Domain.Entities.Common.Enum;
using VelorusNet8.Domain.Entities.Common.ValueObjects;

namespace VelorusNet8.Domain.Entities.Aggregates.Business;

public class BusinessEntity : EntityBase
{
    public int Id { get; set; }
    public string CompanyName { get; private set; }  // Şirket Ünvanı
    public Address Address { get; private set; }  // Adres
    public string PhoneNumber { get; private set; }  // Telefon Numarası
    public string Email { get; private set; }  // E-posta
    public string AccountingCode { get; private set; }  // Muhasebe Kodu
    public string FleetCode { get; private set; }  // Filo Kodu
    public string FuelCardCode { get; private set; }  // Yakıt Kartı Kodu
    public EntityStatus Status { get; private set; }  // Durum Kodu (Aktif/Pasif)
    public string SpecialCode1 { get; private set; }  // Cari Özel Kodu 1
    public string SpecialCode2 { get; private set; }  // Cari Özel Kodu 2
    public string CollateralCode { get; private set; }  // Teminat Kodu
    public string CustomerRepresentativeCode { get; private set; }  // Müşteri Temsilci Personel Kodu
    public string IdentityNumber { get; private set; }  // Kimlik Numarası
    public TaxInformation TaxInformation { get; private set; } // Vergi Numarası & Vergi Dairesi
    public ContactInformation ContactInformation { get; private set; } // İletişim  Bilgileri
    public Branch   Branch { get; private set; } // Şube Adı & Şube Kodu // Şube Adresi
    public AccountBalanceDetails AccountBalanceDetails { get; private set; } // Devir Bakiyeler
    public IList<BankAccount> BankAccounts { get; private set; }  // Banka Bilgileri (Birden Fazla)
    public FinanceGeneralSettings FinanceGeneralSettings { get; private set; }  // Genel Ayarlar
    public FinancialSummary FinancialSummary { get; private set; }  // Mali Toplam Bilgileri
    public bool IsActive { get; private set; }  // Aktif mi Pasif mi?
    public BusinessEntity(int id, string companyName, Address address, string phoneNumber, string email,
                             string accountingCode, string fleetCode, string fuelCardCode, EntityStatus status,
                             string specialCode1, string specialCode2, string collateralCode,
                             string customerRepresentativeCode, string identityNumber,
                             IList<BankAccount> bankAccounts, FinanceGeneralSettings financeGeneralSettings,
                             FinancialSummary financialSummary, UserAccount userAccount, TaxInformation taxInformation,
                             AccountBalanceDetails accountBalanceDetails, Branch branch, ContactInformation contactInformation, int userId , bool isActive = true) : base(userId)
    {
        CompanyName = companyName;
        Address = address;
        PhoneNumber = phoneNumber;
        Email = email;
        AccountingCode = accountingCode;
        FleetCode = fleetCode;
        FuelCardCode = fuelCardCode;
        Status = status;
        SpecialCode1 = specialCode1;
        SpecialCode2 = specialCode2;
        CollateralCode = collateralCode;
        CustomerRepresentativeCode = customerRepresentativeCode;
        IdentityNumber = identityNumber;
        BankAccounts = bankAccounts;
        FinanceGeneralSettings = financeGeneralSettings;
        FinancialSummary = financialSummary;
        TaxInformation = taxInformation;
        AccountBalanceDetails = accountBalanceDetails;
        Branch = branch;
        ContactInformation = contactInformation;
        IsActive = isActive;
    }

    public void UpdateAddress(Address newAddress)
    {
        Address = newAddress;
    }

    public void ChangeAddress(Address newAddress)
    {
        Address = newAddress ?? throw new ArgumentNullException(nameof(newAddress));
    }

    public override bool Equals(object obj)
    {
        return obj is BusinessEntity businessEntity && Id == businessEntity.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}