using VelorusNet8.Domain.Entities.Aggregates.BankTransactions;
using VelorusNet8.Domain.Entities.Aggregates.Users;
using VelorusNet8.Domain.Entities.Common;
using VelorusNet8.Domain.Entities.Common.ValueObjects;

namespace VelorusNet8.Domain.Entities.Aggregates.Banks;

public class Bank : EntityBase
{
        public int Id { get; set; }
        public string AccountCode { get; set; } // Hesap Kodu
        public string AccountName { get; set; } // Hesap Adı
        public string BankName { get; set; } // Banka Adı
        public string BranchName { get; set; } // Şube Adı
        public string AccountIbanNo { get; set; } // Hesap IBAN No
        public string AccountNo { get; set; } // Hesap No
        public string Address { get; set; } // Adres
        public string Phone { get; set; } // Telefon
        public string fax { get; set; } // Faks
        public string Currency { get; set; } // Para Birimi
        public string AccountingCode { get; set; } // Muhasebe Kodu
        public bool UseDbs { get; set; } = false; // DBS Kullan
        public int CheckBankType { get; set; } = 0; // Çek Banka Tipi

        public AccountBalanceDetails AccountBalance { get; set; } // Hesap Bakiyesi Detayları
        public UserAccount userAccount { get; set; }
    // Bir Banka'nın birden fazla BankTransaction'ı olabilir
    public List<BankTransaction> BankTransactions { get; set; } = new List<BankTransaction>(); // Banka Hareketleri
                                                                                           // Constructor
    public Bank(
                   string accountCode, string accountName, string bankName, 
                   string branchName, string accountIbanNo, string accountNo, 
                   string address, string phone, string fax, string currency, 
                   string accountingCode, bool useDbs, int checkBankType, 
                   AccountBalanceDetails accountBalance, int id, UserAccount userAccount, int userId) : base(userId)  // UserId'yi EntityBase constructor'ına geçiyoruz
    {
            AccountCode = accountCode;
            AccountName = accountName;
            BankName = bankName;
            BranchName = branchName;
            AccountIbanNo = accountIbanNo;
            AccountNo = accountNo;
            Address = address;
            Phone = phone;
            this.fax = fax;
            Currency = currency;
            AccountingCode = accountingCode;
            UseDbs = useDbs;
            CheckBankType = checkBankType;
            AccountBalance = accountBalance;
            Id = id;
            this.userAccount = userAccount;
        }


        public override bool Equals(object obj)
        {
            return obj is Bank bank && Id == bank.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
}


