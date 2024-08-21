namespace VelorusNet8.Domain.Entities.Aggregates.Business.ValueOnject;

public class AccountBalanceDetails
{
    public decimal DebitBalance { get; private set; }  // Borç Bakiye
    public decimal CreditBalance { get; private set; }  // Alacak Bakiye
    public decimal OpeningDebitBalance { get; private set; }  // Devir Borç
    public decimal OpeningCreditBalance { get; private set; }  // Devir Alacak

    public AccountBalanceDetails(decimal debitBalance, decimal creditBalance, decimal openingDebitBalance, decimal openingCreditBalance)
    {
        if (debitBalance < 0 || creditBalance < 0 || openingDebitBalance < 0 || openingCreditBalance < 0)
        {
            throw new ArgumentException("Bakiye değerleri negatif olamaz.");
        }

        DebitBalance = debitBalance;
        CreditBalance = creditBalance;
        OpeningDebitBalance = openingDebitBalance;
        OpeningCreditBalance = openingCreditBalance;
    }
    public decimal CalculateNetBalance()
    {
        return (DebitBalance - CreditBalance) + (OpeningDebitBalance - OpeningCreditBalance);
    }

    public override bool Equals(object obj)
    {
        if (obj == null || obj.GetType() != typeof(AccountBalanceDetails))
            return false;

        var other = (AccountBalanceDetails)obj;
        return DebitBalance == other.DebitBalance &&
               CreditBalance == other.CreditBalance &&
               OpeningDebitBalance == other.OpeningDebitBalance &&
               OpeningCreditBalance == other.OpeningCreditBalance;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(DebitBalance, CreditBalance, OpeningDebitBalance, OpeningCreditBalance);
    }

    public override string ToString()
    {
        return $"Debit: {DebitBalance}, Credit: {CreditBalance}, Opening Debit: {OpeningDebitBalance}, Opening Credit: {OpeningCreditBalance}";
    }
}
