namespace VelorusNet8.Domain.Entities.Aggregates.Business.ValueOnject;

public class ContactInformation
{
    public string ContactName { get; private set; }  // İletişim Kişi Adı
    public string ContactPhoneNumber { get; private set; }  // İletişim Telefon Numarası
    public string ContactEmail { get; private set; }  // İletişim E-posta
    public string ContactStatus { get; private set; } // İletişi Statusü

    public ContactInformation(string contactName, string contactPhoneNumber, string contactEmail, string contactStatus)
    {
        if (string.IsNullOrWhiteSpace(contactName))
        {
            throw new ArgumentException("İletişim kişi adı boş olamaz.", nameof(contactName));
        }

        if (string.IsNullOrWhiteSpace(contactPhoneNumber) || !IsValidPhoneNumber(contactPhoneNumber))
        {
            throw new ArgumentException("Geçersiz telefon numarası.", nameof(contactPhoneNumber));
        }

        if (string.IsNullOrWhiteSpace(contactEmail) || !IsValidEmail(contactEmail))
        {
            throw new ArgumentException("Geçersiz e-posta adresi.", nameof(contactEmail));
        }

        ContactName = contactName;
        ContactPhoneNumber = contactPhoneNumber;
        ContactEmail = contactEmail;
        ContactStatus = contactStatus;
    }
    private bool IsValidPhoneNumber(string phoneNumber)
    {
        // Basit bir telefon numarası validasyonu (ülkeye göre değişebilir)
        return phoneNumber.Length >= 10 && phoneNumber.All(char.IsDigit);
    }

    private bool IsValidEmail(string email)
    {
        // Basit bir e-posta validasyonu
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    public override bool Equals(object obj)
    {
        if (obj == null || obj.GetType() != typeof(ContactInformation))
            return false;

        var other = (ContactInformation)obj;
        return ContactName == other.ContactName &&
               ContactPhoneNumber == other.ContactPhoneNumber &&
               ContactEmail == other.ContactEmail;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(ContactName, ContactPhoneNumber, ContactEmail);
    }

    public override string ToString()
    {
        return $"Name: {ContactName}, Phone: {ContactPhoneNumber}, Email: {ContactEmail}";
    }

    public string GetMaskedPhoneNumber()
    {
        // Telefon numarasının son 4 hanesi dışında geri kalanını gizler
        if (ContactPhoneNumber.Length < 4)
            return ContactPhoneNumber;

        return new string('*', ContactPhoneNumber.Length - 4) + ContactPhoneNumber.Substring(ContactPhoneNumber.Length - 4);
    }
}