namespace VelorusNet8.Domain.Entities.Aggregates.Business.ValueOnject;

public class BankAccount
{
    public string BankName { get; private set; }  // Banka İsmi
    public string IBAN { get; private set; }  // IBAN Numarası

    public BankAccount(string bankName, string iban)
    {
        if (string.IsNullOrWhiteSpace(bankName))
        {
            throw new ArgumentException("Banka ismi boş olamaz.", nameof(bankName));
        }

        if (string.IsNullOrWhiteSpace(iban) || !IsValidIBAN(iban))
        {
            throw new ArgumentException("Geçersiz IBAN numarası.", nameof(iban));
        }


        BankName = bankName;
        IBAN = iban;
    }
    private bool IsValidIBAN(string iban)
    {
        // IBAN formatını kontrol eden basit bir validasyon
        return iban.Length >= 15 && iban.Length <= 34;  // Genel IBAN uzunluk kontrolü (ülkelere göre değişebilir)
    }

    public override bool Equals(object obj)
    {
        if (obj == null || obj.GetType() != typeof(BankAccount))
            return false;

        var other = (BankAccount)obj;
        return BankName == other.BankName && IBAN == other.IBAN;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(BankName, IBAN);
    }

    public override string ToString()
    {
        return $"Bank: {BankName}, IBAN: {IBAN}";
    }

    public string GetMaskedIBAN()
    {
        // IBAN numarasının son 4 hanesi dışında geri kalanını gizleyerek gösterir
        if (IBAN.Length < 4)
            return IBAN;

        return new string('*', IBAN.Length - 4) + IBAN.Substring(IBAN.Length - 4);
    }
}