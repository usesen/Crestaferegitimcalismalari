namespace VelorusNet8.Domain.Entities.Common.Enum;

public enum TransactionType
{
    CustomerCreditCardPayment,     // Cari Kredi Kartlı Tahsilat
    CustomerBankPayment,           // Cari Bankadan Tahsilat
    CustomerIssuedChequeNote,      // Cari Verilen Çek/Senet
    CustomerBankPaymentOutgoing,   // Cari Bankadan Ödeme
    BankDeposit,                   // Banka Hesabına Para Yatırma
    BankWithdrawal,                // Banka Hesabından Para Çekme
    EmployeeEFTTransfer,           // Personel Hesabına EFT - Havale
    BankIncome,                    // Banka Gelir
    BankExpense,                   // Banka Gider
    BankTransferOutgoing,          // Bankadan Aktarım
    BankTransferIncoming           // Bankaya Aktarım
}