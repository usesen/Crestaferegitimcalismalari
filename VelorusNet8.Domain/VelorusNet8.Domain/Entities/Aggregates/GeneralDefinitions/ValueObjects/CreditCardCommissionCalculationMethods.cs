namespace VelorusNet8.Domain.Entities.Aggregates.GeneralDefinitions.ValueObjects;

public  class CreditCardCommissionCalculationMethod // kredi kartı komisyon hesaplama yöntemi
{
    public bool UseCommissionRates { get; private set; } // Komisyon oranlarından al
    public bool UseDifference { get; private set; } // Farktan al

    // Constructor
    public CreditCardCommissionCalculationMethod(bool useCommissionRates, bool useDifference)
    {
        UseCommissionRates = useCommissionRates;
        UseDifference = useDifference;
    }

    // Equals metodu
    public override bool Equals(object obj)
    {
        if (obj is CreditCardCommissionCalculationMethod method)
        {
            return UseCommissionRates == method.UseCommissionRates &&
                   UseDifference == method.UseDifference;
        }
        return false;
    }

    // GetHashCode metodu
    public override int GetHashCode()
    {
        return HashCode.Combine(UseCommissionRates, UseDifference);
    }
}
