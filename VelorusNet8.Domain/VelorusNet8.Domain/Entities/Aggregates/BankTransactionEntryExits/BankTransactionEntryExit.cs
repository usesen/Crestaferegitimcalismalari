namespace VelorusNet8.Domain.Entities.Aggregates.BankTransactionEntryExits;

public class BankTransactionEntryExit
{
    public int Id { get; set; } // Ind (Türkçe: ID)
    public int BankId { get; set; } // BankaInd (Türkçe: Banka ID)
    public string BankCode { get; set; } // BankaKodu (Türkçe: Banka Kodu)
    public string BankName { get; set; } // BankaAdi (Türkçe: Banka Adı)
    public DateTime TransactionDate { get; set; } // IslemTarihi (Türkçe: İşlem Tarihi)
    public decimal Amount { get; set; } // Tutar (Türkçe: Tutar)
    public string Description { get; set; } // Aciklama (Türkçe: Açıklama)
    public string TransactionType { get; set; } // IslemTuru (Türkçe: İşlem Türü)
    public string Currency { get; set; } // ParaBirimi (Türkçe: Para Birimi)
    public int StatusId { get; set; } // DurumInd (Türkçe: Durum ID)

    // Constructor
    public BankTransactionEntryExit(int id, int bankId, string bankCode, string bankName, DateTime transactionDate, decimal amount,
                                    string description, string transactionType, string currency, int statusId)
    {
        Id = id;
        BankId = bankId;
        BankCode = bankCode;
        BankName = bankName;
        TransactionDate = transactionDate;
        Amount = amount;
        Description = description;
        TransactionType = transactionType;
        Currency = currency;
        StatusId = statusId;
    }

    // Equals metodu
    public override bool Equals(object obj)
    {
        if (obj is BankTransactionEntryExit entryExit)
        {
            return Id == entryExit.Id &&
                   BankId == entryExit.BankId &&
                   BankCode == entryExit.BankCode &&
                   BankName == entryExit.BankName &&
                   TransactionDate == entryExit.TransactionDate &&
                   Amount == entryExit.Amount &&
                   Description == entryExit.Description &&
                   TransactionType == entryExit.TransactionType &&
                   Currency == entryExit.Currency &&
                   StatusId == entryExit.StatusId;
        }
        return false;
    }

    // GetHashCode metodu
    public override int GetHashCode()
    {
        int hash1 = HashCode.Combine(Id, BankId, BankCode, BankName, TransactionDate);
        int hash2 = HashCode.Combine(Amount, Description, TransactionType, Currency, StatusId);

        return HashCode.Combine(hash1, hash2);
    }
}
