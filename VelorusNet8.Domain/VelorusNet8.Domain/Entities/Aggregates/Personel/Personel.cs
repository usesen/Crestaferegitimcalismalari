using VelorusNet8.Domain.Entities.Aggregates.Users;
using VelorusNet8.Domain.Entities.Common;
using VelorusNet8.Domain.Entities.Common.ValueObjects;

namespace VelorusNet8.Domain.Entities.Aggregates.Personel;

public class PersonnelInformation : EntityBase // personel bilgileri
{
    public string PersonnelCode { get; set; }  // Personel Kodu
    public string FullName { get; set; }  // Adı Soyadı
    public string AutomationCode { get; set; }  // Otomasyon Kodu
    public string Group { get; set; }  // Grubu
    public Address Address { get; set; }  // Adres
    public EmailAddress Email { get; set; }  // Eposta
    public string Phone { get; set; }  // Telefon
    public string Mobile { get; set; }  // Gsm
    public decimal Commission { get; set; }  // Prim
    public decimal NetSalary { get; set; }  // Net Maaş
    public decimal TaxReduction { get; set; }  // iA.G.İ (Income Tax Reduction)
    public DateTime StartDate { get; set; }  // Giriş tarihi
    public DateTime? TerminationDate { get; set; }  // İşten ayrılma tarihi
    public string NationalId { get; set; }  // Kimlik No
    public string VendorCode { get; set; }  // Satıcı Kod
    public string TerminationReason { get; set; }  // Ayrılma Sebebi
    public bool IsActive { get; set; } // aktif / pasif
   
 
    // Tüm özellikleri alan constructor
    public PersonnelInformation(
        string personnelCode,
        string fullName,
        string automationCode,
        string group,
        Address address,
        EmailAddress email,
        string phone,
        string mobile,
        decimal commission,
        decimal netSalary,
        decimal taxReduction,
        DateTime startDate,
        DateTime? terminationDate,
        string nationalId,
        string vendorCode,
        string terminationReason,
        int userId)  : base(userId)
    {
        PersonnelCode = personnelCode;
        FullName = fullName;
        AutomationCode = automationCode;
        Group = group;
        Address = address;
        Email = email;
        Phone = phone;
        Mobile = mobile;
        Commission = commission;
        NetSalary = netSalary;
        TaxReduction = taxReduction;
        StartDate = startDate;
        TerminationDate = terminationDate;
        NationalId = nationalId;
        VendorCode = vendorCode;
        TerminationReason = terminationReason;
    }
 
    public override int GetHashCode()
    {
        int hash1 = HashCode.Combine(PersonnelCode, FullName, AutomationCode, Group, Address, Email, Phone, Mobile);
        int hash2 = HashCode.Combine(Commission, NetSalary, TaxReduction, StartDate, TerminationDate);
        int hash3 = HashCode.Combine(NationalId, VendorCode, TerminationReason);

        return HashCode.Combine(hash1, hash2, hash3);
    }
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        var other = (PersonnelInformation)obj;
        return PersonnelCode == other.PersonnelCode &&
               FullName == other.FullName &&
               AutomationCode == other.AutomationCode &&
               Group == other.Group &&
               Address == other.Address &&
               Email == other.Email &&
               Phone == other.Phone &&
               Mobile == other.Mobile &&
               Commission == other.Commission &&
               NetSalary == other.NetSalary &&
               TaxReduction == other.TaxReduction &&
               StartDate == other.StartDate &&
               TerminationDate == other.TerminationDate &&
               NationalId == other.NationalId &&
               VendorCode == other.VendorCode &&
               TerminationReason == other.TerminationReason;
    }

}

