using VelorusNet8.Domain.Entities.Aggregates.User;
using VelorusNet8.Domain.Entities.Common;
using VelorusNet8.Domain.Entities.Common.ValueObjects;

namespace VelorusNet8.Domain.Entities.Aggregates.Personel;

public class Personel : EntityBase
{
    public string FirstName { get; private set; }  // Personelin Adı
    public string LastName { get; private set; }  // Personelin Soyadı
    public string NationalId { get; private set; }  // T.C. Kimlik Numarası
    public string Email { get; private set; }  // Personel E-posta Adresi
    public string PhoneNumber { get; private set; }  // Telefon Numarası
    public Address Address { get; private set; }  // Adres Bilgisi (Value Object olarak tanımlanmış Address)
    public DateTime HireDate { get; private set; }  // İşe Başlama Tarihi
    public string Position { get; private set; }  // Personelin Pozisyonu
    public decimal Salary { get; private set; }  // Maaş Bilgisi
    public bool IsActive { get; private set; }  // Aktif mi Pasif mi?
    public string OtomasyonKodu { get; private set; }  // Otomasyon Kodu
    public string Department { get; private set; }  // Departman
    public string Grubu { get; private set; }  // Grubu
    public decimal BorcBakiye { get; private set; }  // Borç Bakiye
    public decimal AlacakBakiye { get; private set; }  // Alacak Bakiye
    public decimal Prim { get; private set; }  // Prim
    public DateTime GirisTarihi { get; private set; }  // Giriş Tarihi
    public string Aciklama { get; private set; }  // Açıklama

    public Personel(int id, UserAccount account, string firstName, string lastName, string nationalId, string email, string phoneNumber, Address address, DateTime hireDate, string position, decimal salary, string otomasyonKodu, string department, string grubu, decimal borcBakiye, decimal alacakBakiye, decimal prim, DateTime girisTarihi, string aciklama)
        : base(account)
    {
        FirstName = firstName;
        LastName = lastName;
        NationalId = nationalId;
        Email = email;
        PhoneNumber = phoneNumber;
        Address = address;
        HireDate = hireDate;
        Position = position;
        Salary = salary;
        OtomasyonKodu = otomasyonKodu;
        Department = department;
        Grubu = grubu;
        BorcBakiye = borcBakiye;
        AlacakBakiye = alacakBakiye;
        Prim = prim;
        GirisTarihi = girisTarihi;
        Aciklama = aciklama;
        IsActive = true; // Default olarak aktif
    }

    // Personelin bilgilerini güncellemek için metodlar
    public void UpdateContactInformation(string email, string phoneNumber)
    {
        Email = email;
        PhoneNumber = phoneNumber;
        UpdateEntity();
    }

    public void UpdateAddress(Address newAddress)
    {
        Address = newAddress;
        UpdateEntity();
    }

    public void ChangePosition(string newPosition, decimal newSalary)
    {
        Position = newPosition;
        Salary = newSalary;
        UpdateEntity();
    }

    public void UpdateFinancials(decimal borcBakiye, decimal alacakBakiye, decimal prim)
    {
        BorcBakiye = borcBakiye;
        AlacakBakiye = alacakBakiye;
        Prim = prim;
        UpdateEntity();
    }

    public void Deactivate()
    {
        IsActive = false;
        UpdateEntity();
    }

    public void Activate()
    {
        IsActive = true;
        UpdateEntity();
    }
}

