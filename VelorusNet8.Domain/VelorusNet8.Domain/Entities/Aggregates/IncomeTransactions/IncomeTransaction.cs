namespace VelorusNet8.Domain.Entities.Aggregates.IncomeTransactions;

public class IncomeTransaction
{
    public DateTime? EntryDate { get; set; } // GirisTarihi (Türkçe: Giriş Tarihi)
    public string Location { get; set; } // Yer (Türkçe: Yer)
    public string Description { get; set; } // Aciklama (Türkçe: Açıklama)
    public decimal Amount { get; set; } // Tutar (Türkçe: Tutar)
    public string CustomerAccountName { get; set; } // CariHesapAdi (Türkçe: Cari Hesap Adı)

    // Constructor
    public IncomeTransaction(DateTime? entryDate, string location, string description, decimal amount, string customerAccountName)
    {
        EntryDate = entryDate;
        Location = location;
        Description = description;
        Amount = amount;
        CustomerAccountName = customerAccountName;
    }

    // GetYetkiInd methodu
    public int GetPermissionIndex()
    {
        return 0; // GetYetkiInd (Türkçe: Yetki İndeksini Al)
    }

    // Validate methodu
    public bool Validate()
    {
        return true; // Validate (Türkçe: Doğrula)
    }

    // Equals metodu
    public override bool Equals(object obj)
    {
        if (obj is IncomeTransaction transaction)
        {
            return EntryDate == transaction.EntryDate &&
                   Location == transaction.Location &&
                   Description == transaction.Description &&
                   Amount == transaction.Amount &&
                   CustomerAccountName == transaction.CustomerAccountName;
        }
        return false;
    }

    // GetHashCode metodu
    public override int GetHashCode()
    {
        return HashCode.Combine(EntryDate, Location, Description, Amount, CustomerAccountName);
    }
}

