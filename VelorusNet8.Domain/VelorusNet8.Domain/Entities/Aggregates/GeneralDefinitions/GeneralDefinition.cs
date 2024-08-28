using VelorusNet8.Domain.Entities.Aggregates.GeneralDefinitions.ValueObjects;
using VelorusNet8.Domain.Entities.Aggregates.Users;
using VelorusNet8.Domain.Entities.Common;

namespace VelorusNet8.Domain.Entities.Aggregates.GeneralDefinitions;

public  class GeneralDefinition : EntityBase
{
    public int Id { get; set; }
    public Int32 PaginationRecordsPerPage { get; set; } //Sayfalama - Sayfadaki Kayıt Sayısı
    public bool ListingVerticallyExpanded { get; set; } = false; //(Kasa, Kasa Hareket Dökümü, Cari B/A Raporu, Sipariş Listeleri)
    public bool ShowDateRange { get; set; } = true; // (Borçlu - Alacaklı Listesi, Satış İrsaliyesi Faturalandırma, Cirolu Çekler Raporu, İrsaliye Dökümleri, Plaka Bazlı İrsaliye Dökümleri, Sipariş Listesi, Onaylanan Siparişler)
    public int AutomaticDocumentNumber { get; set; } //Otomatik Belge No.
    public int ExcludePreviousYearCarryOverAmounts { get; set; } // Gelir-Gider Hareket Dökümünde Geçen Seneye Ait Devir Tutarları Getirilmesin
    public UserAccount UserAccount { get; set; }


    // Value Objects
    public Bilanco Bilanco { get; set; } // Bilanço
    public CreditCardCommissionCalculationMethod CreditCardCommissionCalculationMethod { get; set; } // Kredi Kartı Komisyon Hesaplama Yöntemi
    public CurrentAccount CurrentAccount { get; set; } // Cari
    public Email Email { get; set; } // E-Posta
    public Invoice Invoices { get; set; } // Fatura
    public Personnel Personnel { get; set; } // Personel
    public ProfitandLossCostCalculation ProfitandLossCostCalculation { get; set; } // Kar Zarar - Maliyet Hesabı
    public Stock Stock { get; set; } // Stok
    // Constructor
    public GeneralDefinition(int id, int paginationRecordsPerPage, bool listingVerticallyExpanded, bool showDateRange,
                             int automaticDocumentNumber, int excludePreviousYearCarryOverAmounts, UserAccount userAccount,
                             Bilanco bilanco, CreditCardCommissionCalculationMethod creditCardCommissionCalculationMethod,
                             CurrentAccount currentAccount, Email email, Invoice invoices, Personnel personnel,
                             ProfitandLossCostCalculation profitandLossCostCalculation, Stock stock,int userId) : base()
    {
        Id = this.Id;
        PaginationRecordsPerPage = paginationRecordsPerPage;
        ListingVerticallyExpanded = listingVerticallyExpanded;
        ShowDateRange = showDateRange;
        AutomaticDocumentNumber = automaticDocumentNumber;
        ExcludePreviousYearCarryOverAmounts = excludePreviousYearCarryOverAmounts;
        UserAccount = userAccount;
        Bilanco = bilanco;
        CreditCardCommissionCalculationMethod = creditCardCommissionCalculationMethod;
        CurrentAccount = currentAccount;
        Email = email;
        Invoices = invoices;
        Personnel = personnel;
        ProfitandLossCostCalculation = profitandLossCostCalculation;
        Stock = stock;
    }

    // Equals metodu
    public override bool Equals(object obj)
    {
        if (obj is GeneralDefinition definition)
        {
            return Id == definition.Id &&
                   PaginationRecordsPerPage == definition.PaginationRecordsPerPage &&
                   ListingVerticallyExpanded == definition.ListingVerticallyExpanded &&
                   ShowDateRange == definition.ShowDateRange &&
                   AutomaticDocumentNumber == definition.AutomaticDocumentNumber &&
                   ExcludePreviousYearCarryOverAmounts == definition.ExcludePreviousYearCarryOverAmounts &&
                   EqualityComparer<UserAccount>.Default.Equals(UserAccount, definition.UserAccount) &&
                   EqualityComparer<Bilanco>.Default.Equals(Bilanco, definition.Bilanco) &&
                   EqualityComparer<CreditCardCommissionCalculationMethod>.Default.Equals(CreditCardCommissionCalculationMethod, definition.CreditCardCommissionCalculationMethod) &&
                   EqualityComparer<CurrentAccount>.Default.Equals(CurrentAccount, definition.CurrentAccount) &&
                   EqualityComparer<Email>.Default.Equals(Email, definition.Email) &&
                   EqualityComparer<Invoice>.Default.Equals(Invoices, definition.Invoices) &&
                   EqualityComparer<Personnel>.Default.Equals(Personnel, definition.Personnel) &&
                   EqualityComparer<ProfitandLossCostCalculation>.Default.Equals(ProfitandLossCostCalculation, definition.ProfitandLossCostCalculation) &&
                   EqualityComparer<Stock>.Default.Equals(Stock, definition.Stock);
        }
        return false;
    }

    // GetHashCode metodu
    public override int GetHashCode()
    {
        int hash1 = HashCode.Combine(Id, PaginationRecordsPerPage, ListingVerticallyExpanded, ShowDateRange, AutomaticDocumentNumber);
        int hash2 = HashCode.Combine(ExcludePreviousYearCarryOverAmounts, UserAccount, Bilanco, CreditCardCommissionCalculationMethod, CurrentAccount);
        int hash3 = HashCode.Combine(Email, Invoices, Personnel, ProfitandLossCostCalculation, Stock);

        return HashCode.Combine(hash1, hash2, hash3);
    }
}
