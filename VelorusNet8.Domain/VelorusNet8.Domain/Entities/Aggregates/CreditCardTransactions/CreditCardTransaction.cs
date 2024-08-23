namespace VelorusNet8.Domain.Entities.Aggregates.CreditCardTransactions;

public class CreditCardTransactions
{
    public int Id { get; set; } // Ind
    public int? TitleId { get; set; } // BaslikInd
    public int CreditCardAccountId { get; set; } // KKHesapInd
    public string CreditCardAccountCode { get; set; } // KKHesapKodu
    public string CreditCardAccountName { get; set; } // KKHesapAdi
    public string Description { get; set; } // Aciklama
    public int CustomerAccountId { get; set; } // CariHesapInd
    public string CustomerAccountCode { get; set; } // CariHesapKodu
    public string CustomerAccountName { get; set; } // CariHesapAdi
    public DateTime? EntryDate { get; set; } // GirisTarihi
    public DateTime? DueDate { get; set; } // VadeTarihi
    public string Currency { get; set; } // ParaBirimi
    public decimal Amount { get; set; } // Tutar
    public string EndOfDay { get; set; } // GunSonu
    public int StatusId { get; set; } // DurumInd
    public int ShiftCardId { get; set; } // VardiyaKartInd

    // Constructor
    public CreditCardTransactions(int id, int? titleId, int creditCardAccountId, string creditCardAccountCode, string creditCardAccountName, string description, int customerAccountId,
                                  string customerAccountCode, string customerAccountName, DateTime? entryDate, DateTime? dueDate, string currency,
                                  decimal amount, string endOfDay, int statusId, int shiftCardId)
    {
        Id = id;
        TitleId = titleId;
        CreditCardAccountId = creditCardAccountId;
        CreditCardAccountCode = creditCardAccountCode;
        CreditCardAccountName = creditCardAccountName;
        Description = description;
        CustomerAccountId = customerAccountId;
        CustomerAccountCode = customerAccountCode;
        CustomerAccountName = customerAccountName;
        EntryDate = entryDate;
        DueDate = dueDate;
        Currency = currency;
        Amount = amount;
        EndOfDay = endOfDay;
        StatusId = statusId;
        ShiftCardId = shiftCardId;
    }

    // Equals metodu
    public override bool Equals(object obj)
    {
        if (obj is CreditCardTransactions transaction)
        {
            return Id == transaction.Id &&
                   TitleId == transaction.TitleId &&
                   CreditCardAccountId == transaction.CreditCardAccountId &&
                   CreditCardAccountCode == transaction.CreditCardAccountCode &&
                   CreditCardAccountName == transaction.CreditCardAccountName &&
                   Description == transaction.Description &&
                   CustomerAccountId == transaction.CustomerAccountId &&
                   CustomerAccountCode == transaction.CustomerAccountCode &&
                   CustomerAccountName == transaction.CustomerAccountName &&
                   EntryDate == transaction.EntryDate &&
                   DueDate == transaction.DueDate &&
                   Currency == transaction.Currency &&
                   Amount == transaction.Amount &&
                   EndOfDay == transaction.EndOfDay &&
                   StatusId == transaction.StatusId &&
                   ShiftCardId == transaction.ShiftCardId;
        }
        return false;
    }

    // GetHashCode metodu
    public override int GetHashCode()
    {
        int hash1 = HashCode.Combine(Id, TitleId, CreditCardAccountId, CreditCardAccountCode, CreditCardAccountName, Description, CustomerAccountId, CustomerAccountCode);
        int hash2 = HashCode.Combine(CustomerAccountName, EntryDate, DueDate, Currency, Amount, EndOfDay, StatusId, ShiftCardId);

        return HashCode.Combine(hash1, hash2);
    }
}
