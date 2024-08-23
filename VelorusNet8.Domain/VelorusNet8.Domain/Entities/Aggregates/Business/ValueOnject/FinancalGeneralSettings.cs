namespace VelorusNet8.Domain.Entities.Aggregates.Business.ValueOnject;

public class FinanceGeneralSettings
{
    public int InvoiceDueDays { get; private set; }  // Fatura Vadesi
    public int GeneralPaymentDueDays { get; private set; }  // Genel Ödeme Vadesi
    public decimal DiscountByDueDate { get; private set; }  // Vade Bazlı İskonto
    public int BranchPaymentDueDays { get; private set; }  // Şube Bazlı Ödeme Vadeleri
    public string ReceiptPortfolio { get; private set; }  // Fiş Portföyü
    public decimal InterestRate { get; private set; }  // Faiz
    public decimal DiscountRate1 { get; private set; }  // İskonto Oranı %
    public decimal DiscountAmount1 { get; private set; }  // İskonto Oranı TL
    public decimal DiscountRate2 { get; private set; }  // İskonto Oranı 2 %
    public decimal DiscountAmount2 { get; private set; }  // İskonto Oranı 2 TL
    public decimal RiskAmountLocal { get; private set; }  // Risk Tutarı (LT)
    public decimal RiskAmountForeign { get; private set; }  // Risk Tutarı TL
    public string CustomerLocation { get; private set; }  // Cari Lokasyon

    public FinanceGeneralSettings(int invoiceDueDays, int generalPaymentDueDays, decimal discountByDueDate,
                           int branchPaymentDueDays, string receiptPortfolio, decimal interestRate,
                           decimal discountRate1, decimal discountAmount1, decimal discountRate2,
                           decimal discountAmount2, decimal riskAmountLocal, decimal riskAmountForeign,
                           string customerLocation)
    {
        if (invoiceDueDays < 0 || generalPaymentDueDays < 0 || discountByDueDate < 0 ||
            branchPaymentDueDays < 0 || interestRate < 0 || discountRate1 < 0 || discountAmount1 < 0 ||
            discountRate2 < 0 || discountAmount2 < 0 || riskAmountLocal < 0 || riskAmountForeign < 0)
        {
            throw new ArgumentException("Finansal değerler negatif olamaz.");
        }

        if (string.IsNullOrWhiteSpace(receiptPortfolio))
        {
            throw new ArgumentException("Fiş portföyü geçerli olmalıdır.", nameof(receiptPortfolio));
        }

        if (string.IsNullOrWhiteSpace(customerLocation))
        {
            throw new ArgumentException("Cari lokasyon geçerli olmalıdır.", nameof(customerLocation));
        }

        InvoiceDueDays = invoiceDueDays;
        GeneralPaymentDueDays = generalPaymentDueDays;
        DiscountByDueDate = discountByDueDate;
        BranchPaymentDueDays = branchPaymentDueDays;
        ReceiptPortfolio = receiptPortfolio;
        InterestRate = interestRate;
        DiscountRate1 = discountRate1;
        DiscountAmount1 = discountAmount1;
        DiscountRate2 = discountRate2;
        DiscountAmount2 = discountAmount2;
        RiskAmountLocal = riskAmountLocal;
        RiskAmountForeign = riskAmountForeign;
        CustomerLocation = customerLocation;
    }
    public override int GetHashCode()
    {
        int hash = HashCode.Combine(InvoiceDueDays, GeneralPaymentDueDays, DiscountByDueDate, BranchPaymentDueDays,
                                    ReceiptPortfolio, InterestRate, DiscountRate1, DiscountAmount1);

        hash = HashCode.Combine(hash, DiscountRate2, DiscountAmount2, RiskAmountLocal, RiskAmountForeign, CustomerLocation);

        return hash;
    }
    public override bool Equals(object obj)
    {
        return obj is FinanceGeneralSettings settings &&
               InvoiceDueDays == settings.InvoiceDueDays &&
               GeneralPaymentDueDays == settings.GeneralPaymentDueDays &&
               DiscountByDueDate == settings.DiscountByDueDate &&
               BranchPaymentDueDays == settings.BranchPaymentDueDays &&
               ReceiptPortfolio == settings.ReceiptPortfolio &&
               InterestRate == settings.InterestRate &&
               DiscountRate1 == settings.DiscountRate1 &&
               DiscountAmount1 == settings.DiscountAmount1 &&
               DiscountRate2 == settings.DiscountRate2 &&
               DiscountAmount2 == settings.DiscountAmount2 &&
               RiskAmountLocal == settings.RiskAmountLocal &&
               RiskAmountForeign == settings.RiskAmountForeign &&
               CustomerLocation == settings.CustomerLocation;
    }

}
