namespace VelorusNet8.Domain.Entities.Aggregates.CheckNoteTransactions;

public class CheckNoteTransaction
{
    public int Id { get; set; } // Ind (Türkçe: ID)
    public int? StatusId { get; set; } // DurumInd (Türkçe: Durum ID)
    public int CustomerAccountId { get; set; } // CariHesapInd (Türkçe: Cari Hesap ID)
    public string CustomerAccountCode { get; set; } // CariHesapKodu (Türkçe: Cari Hesap Kodu)
    public string CustomerAccountName { get; set; } // CariHesapAdi (Türkçe: Cari Hesap Adı)
    public int BankAccountId { get; set; } // BankaHesapInd (Türkçe: Banka Hesap ID)
    public string BankAccountCode { get; set; } // BankaHesapKodu (Türkçe: Banka Hesap Kodu)
    public string BankAccountName { get; set; } // BankaHesapAdi (Türkçe: Banka Hesap Adı)
    public DateTime? DueDate { get; set; } // VadeTarihi (Türkçe: Vade Tarihi)
    public DateTime? EntryDate { get; set; } // GirisTarihi (Türkçe: Giriş Tarihi)
    public DateTime? TransferDate { get; set; } // AktarimTarihi (Türkçe: Aktarım Tarihi)
    public string CheckNumber { get; set; } // CekNo (Türkçe: Çek No)
    public string Description { get; set; } // Aciklama (Türkçe: Açıklama)
    public string BankDescription { get; set; } // BankaAciklama (Türkçe: Banka Açıklama)
    public decimal Amount { get; set; } // Tutar (Türkçe: Tutar)
    public string CheckOwner { get; set; } // CekSahibi (Türkçe: Çek Sahibi)
    public string Currency { get; set; } // ParaBirimi (Türkçe: Para Birimi)
    public int? EndorsementBankId { get; set; } // CiroBankaInd (Türkçe: Ciro Banka ID)
    public string EndorsementBankCode { get; set; } // CiroBankaKodu (Türkçe: Ciro Banka Kodu)
    public string EndorsementBankName { get; set; } // CiroBankaAdi (Türkçe: Ciro Banka Adı)
    public int? EndorsementCustomerId { get; set; } // CiroCariInd (Türkçe: Ciro Cari ID)
    public string EndorsementCustomerCode { get; set; } // CiroCariKodu (Türkçe: Ciro Cari Kodu)
    public string EndorsementCustomerName { get; set; } // CiroCariAdi (Türkçe: Ciro Cari Adı)
    public DateTime? TransactionDate { get; set; } // IslemTarihi (Türkçe: İşlem Tarihi)
    public bool? IsNote { get; set; } // Senet (Türkçe: Senet)
    public bool? IsTransferred { get; set; } // Aktarildi (Türkçe: Aktarıldı)

    // Constructor
    public CheckNoteTransaction(int id, int? statusId, int customerAccountId, string customerAccountCode, string customerAccountName,
                                int bankAccountId, string bankAccountCode, string bankAccountName, DateTime? dueDate, DateTime? entryDate,
                                DateTime? transferDate, string checkNumber, string description, string bankDescription, decimal amount,
                                string checkOwner, string currency, int? endorsementBankId, string endorsementBankCode,
                                string endorsementBankName, int? endorsementCustomerId, string endorsementCustomerCode,
                                string endorsementCustomerName, DateTime? transactionDate, bool? isNote, bool? isTransferred)
    {
        Id = id;
        StatusId = statusId;
        CustomerAccountId = customerAccountId;
        CustomerAccountCode = customerAccountCode;
        CustomerAccountName = customerAccountName;
        BankAccountId = bankAccountId;
        BankAccountCode = bankAccountCode;
        BankAccountName = bankAccountName;
        DueDate = dueDate;
        EntryDate = entryDate;
        TransferDate = transferDate;
        CheckNumber = checkNumber;
        Description = description;
        BankDescription = bankDescription;
        Amount = amount;
        CheckOwner = checkOwner;
        Currency = currency;
        EndorsementBankId = endorsementBankId;
        EndorsementBankCode = endorsementBankCode;
        EndorsementBankName = endorsementBankName;
        EndorsementCustomerId = endorsementCustomerId;
        EndorsementCustomerCode = endorsementCustomerCode;
        EndorsementCustomerName = endorsementCustomerName;
        TransactionDate = transactionDate;
        IsNote = isNote;
        IsTransferred = isTransferred;
    }

    // Equals metodu
    public override bool Equals(object obj)
    {
        if (obj is CheckNoteTransaction transaction)
        {
            return Id == transaction.Id &&
                   StatusId == transaction.StatusId &&
                   CustomerAccountId == transaction.CustomerAccountId &&
                   CustomerAccountCode == transaction.CustomerAccountCode &&
                   CustomerAccountName == transaction.CustomerAccountName &&
                   BankAccountId == transaction.BankAccountId &&
                   BankAccountCode == transaction.BankAccountCode &&
                   BankAccountName == transaction.BankAccountName &&
                   DueDate == transaction.DueDate &&
                   EntryDate == transaction.EntryDate &&
                   TransferDate == transaction.TransferDate &&
                   CheckNumber == transaction.CheckNumber &&
                   Description == transaction.Description &&
                   BankDescription == transaction.BankDescription &&
                   Amount == transaction.Amount &&
                   CheckOwner == transaction.CheckOwner &&
                   Currency == transaction.Currency &&
                   EndorsementBankId == transaction.EndorsementBankId &&
                   EndorsementBankCode == transaction.EndorsementBankCode &&
                   EndorsementBankName == transaction.EndorsementBankName &&
                   EndorsementCustomerId == transaction.EndorsementCustomerId &&
                   EndorsementCustomerCode == transaction.EndorsementCustomerCode &&
                   EndorsementCustomerName == transaction.EndorsementCustomerName &&
                   TransactionDate == transaction.TransactionDate &&
                   IsNote == transaction.IsNote &&
                   IsTransferred == transaction.IsTransferred;
        }
        return false;
    }

    // GetHashCode metodu
    public override int GetHashCode()
    {
        int hash1 = HashCode.Combine(Id, StatusId, CustomerAccountId, CustomerAccountCode, CustomerAccountName);
        int hash2 = HashCode.Combine(BankAccountId, BankAccountCode, BankAccountName, DueDate, EntryDate);
        int hash3 = HashCode.Combine(TransferDate, CheckNumber, Description, BankDescription, Amount);
        int hash4 = HashCode.Combine(CheckOwner, Currency, EndorsementBankId, EndorsementBankCode, EndorsementBankName);
        int hash5 = HashCode.Combine(EndorsementCustomerId, EndorsementCustomerCode, EndorsementCustomerName, TransactionDate, IsNote);
        int hash6 = HashCode.Combine(IsTransferred);

        return HashCode.Combine(hash1, hash2, hash3, hash4, hash5, hash6);
    }

}
