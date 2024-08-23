namespace VelorusNet8.Domain.Entities.Aggregates.ExpenseTransactions;

public class ExpenseTransaction // gider hareketleri
{
    public int TypeId { get; set; } // TipInd (Türkçe: Tip ID)
    public DateTime? EntryDate { get; set; } // GirisTarihi (Türkçe: Giriş Tarihi)
    public string Location { get; set; } // Yer (Türkçe: Yer)
    public string Description { get; set; } // Aciklama (Türkçe: Açıklama)
    public decimal BaseAmount { get; set; } // Matrah (Türkçe: Matrah)
    public decimal VAT { get; set; } // KDV (Türkçe: KDV)
    public decimal Amount { get; set; } // Tutar (Türkçe: Tutar)
    public int? ShiftCardId { get; set; } // VardiyaKartInd (Türkçe: Vardiya Kart ID)
    public string CustomerAccountName { get; set; } // CariHesapAdi (Türkçe: Cari Hesap Adı)
    public int? PersonnelAccountId { get; set; } // PersonelHesapInd (Türkçe: Personel Hesap ID)

    // Constructor
    public ExpenseTransaction(int typeId, DateTime? entryDate, string location, string description, decimal baseAmount,
                              decimal vat, decimal amount, int? shiftCardId, string customerAccountName, int? personnelAccountId)
    {
        TypeId = typeId;
        EntryDate = entryDate;
        Location = location;
        Description = description;
        BaseAmount = baseAmount;
        VAT = vat;
        Amount = amount;
        ShiftCardId = shiftCardId;
        CustomerAccountName = customerAccountName;
        PersonnelAccountId = personnelAccountId;
    }

    // Equals metodu
    public override bool Equals(object obj)
    {
        if (obj is ExpenseTransaction transaction)
        {
            return TypeId == transaction.TypeId &&
                   EntryDate == transaction.EntryDate &&
                   Location == transaction.Location &&
                   Description == transaction.Description &&
                   BaseAmount == transaction.BaseAmount &&
                   VAT == transaction.VAT &&
                   Amount == transaction.Amount &&
                   ShiftCardId == transaction.ShiftCardId &&
                   CustomerAccountName == transaction.CustomerAccountName &&
                   PersonnelAccountId == transaction.PersonnelAccountId;
        }
        return false;
    }

    // GetHashCode metodu
    public override int GetHashCode()
    {
        int hash1 = HashCode.Combine(TypeId, EntryDate, Location, Description, BaseAmount);
        int hash2 = HashCode.Combine(VAT, Amount, ShiftCardId, CustomerAccountName, PersonnelAccountId);

        return HashCode.Combine(hash1, hash2);
    }
}

