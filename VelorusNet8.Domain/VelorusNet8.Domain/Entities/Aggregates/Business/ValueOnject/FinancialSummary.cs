
namespace VelorusNet8.Domain.Entities.Aggregates.Business.ValueOnject;

public class FinancialSummary
{
    public decimal ReceivedChecks { get; private set; }  // Alınan Çek/Senet
    public decimal AccountReceivable { get; private set; }  // Cari Hesap
    public decimal GivenChecks { get; private set; }  // Verilen Çek/Senet
    public decimal ManualReceiptTL { get; private set; }  // Manual irs./fiş (TL)
    public decimal ManualReceiptLT { get; private set; }  // Manual irs./fiş (LT)
    public decimal VehicleRecognitionReceiptTL { get; private set; }  // Taşıt Tanıma irs./Fiş Toplamı (TL)
    public decimal VehicleRecognitionReceiptLT { get; private set; }  // Taşıt Tanıma irs./Fiş Toplamı (LT)
    public string Currency { get; private set; }  // Para Birimi

    public FinancialSummary(decimal receivedChecks, decimal accountReceivable, decimal givenChecks,
                            decimal manualReceiptTL, decimal manualReceiptLT, decimal vehicleRecognitionReceiptTL,
                            decimal vehicleRecognitionReceiptLT, string currency)
    {
        if (receivedChecks < 0 || accountReceivable < 0 || givenChecks < 0 ||
            manualReceiptTL < 0 || manualReceiptLT < 0 || vehicleRecognitionReceiptTL < 0 || vehicleRecognitionReceiptLT < 0)
        {
            throw new ArgumentException("Finansal değerler negatif olamaz.");
        }

        if (string.IsNullOrWhiteSpace(currency))
        {
            throw new ArgumentException("Para birimi geçerli olmalıdır.", nameof(currency));
        }

        ReceivedChecks = receivedChecks;
        AccountReceivable = accountReceivable;
        GivenChecks = givenChecks;
        ManualReceiptTL = manualReceiptTL;
        ManualReceiptLT = manualReceiptLT;
        VehicleRecognitionReceiptTL = vehicleRecognitionReceiptTL;
        VehicleRecognitionReceiptLT = vehicleRecognitionReceiptLT;
        Currency = currency;
    }
    public decimal CalculateNetBalance()
    {
        return AccountReceivable - (ReceivedChecks + GivenChecks);
    }

    public decimal CalculateTotalChecks()
    {
        return ReceivedChecks + GivenChecks;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || obj.GetType() != typeof(FinancialSummary))
            return false;

        var other = (FinancialSummary)obj;
        return ReceivedChecks == other.ReceivedChecks &&
               AccountReceivable == other.AccountReceivable &&
               GivenChecks == other.GivenChecks &&
               ManualReceiptTL == other.ManualReceiptTL &&
               ManualReceiptLT == other.ManualReceiptLT &&
               VehicleRecognitionReceiptTL == other.VehicleRecognitionReceiptTL &&
               VehicleRecognitionReceiptLT == other.VehicleRecognitionReceiptLT &&
               Currency == other.Currency;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(ReceivedChecks, AccountReceivable, GivenChecks, ManualReceiptTL,
                                ManualReceiptLT, VehicleRecognitionReceiptTL, VehicleRecognitionReceiptLT, Currency);
    }

    public override string ToString()
    {
        return $"Received Checks: {ReceivedChecks} {Currency}, Account Receivable: {AccountReceivable} {Currency}, " +
               $"Given Checks: {GivenChecks} {Currency}, Manual Receipt TL: {ManualReceiptTL} {Currency}, " +
               $"Manual Receipt LT: {ManualReceiptLT} {Currency}, Vehicle Recognition Receipt TL: {VehicleRecognitionReceiptTL} {Currency}, " +
               $"Vehicle Recognition Receipt LT: {VehicleRecognitionReceiptLT} {Currency}";
    }
}
