using VelorusNet8.Domain.Entities.Aggregates.Banks;
using VelorusNet8.Domain.Entities.Aggregates.Users;
using VelorusNet8.Domain.Entities.Common;
using VelorusNet8.Domain.Entities.Common.Enum;

namespace VelorusNet8.Domain.Entities.Aggregates.BankTransactions;

public class BankTransaction : EntityBase
{
    public int Id { get; set; }
    public DateTime TransactionDate { get; set; } // İşlem Tarihi
    public decimal Amount { get; set; } // Tutar
    public string Description { get; set; } // Açıklama
    public TransactionType TransactionType { get; set; } // İşlem Türü (Giriş, Çıkış)
    public int BankId { get; set; } // Banka Id (Yabancı anahtar)
    public UserAccount userAccount { get; set; }
    public Bank Bank { get; set; } // İlgili Banka
    // Constructor
    public BankTransaction(int id, DateTime transactionDate, decimal amount, string description, TransactionType transactionType, int bankId, int userId) : base()
      
    {
        Id = id;
        TransactionDate = transactionDate;
        Amount = amount;
        Description = description;
        TransactionType = transactionType;
        BankId = bankId;
    }

    public override bool Equals(object obj)
    {
        return obj is BankTransaction transaction && Id == transaction.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
