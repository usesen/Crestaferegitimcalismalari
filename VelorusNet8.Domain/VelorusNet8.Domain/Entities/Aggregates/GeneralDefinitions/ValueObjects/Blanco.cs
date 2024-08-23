namespace VelorusNet8.Domain.Entities.Aggregates.GeneralDefinitions.ValueObjects;

public class Bilanco
{
    public bool ProfitandLoss { get; private set; } // Kar Zarar (Toplam Mal Satış Karına KDV eklensin)
    public bool IsNetProfitLossCalculated { get; private set; } // Net Kar Zarar hesaplansın
    public bool IsBranchSpecificCalculated { get; private set; } // Şubeler özgün hesaplansın

    // Constructor
    public Bilanco(bool profitandLoss, bool isNetProfitLossCalculated, bool isBranchSpecificCalculated)
    {
        ProfitandLoss = profitandLoss;
        IsNetProfitLossCalculated = isNetProfitLossCalculated;
        IsBranchSpecificCalculated = isBranchSpecificCalculated;
    }

    // Equals metodu
    public override bool Equals(object obj)
    {
        if (obj is Bilanco bilanco)
        {
            return ProfitandLoss == bilanco.ProfitandLoss &&
                   IsNetProfitLossCalculated == bilanco.IsNetProfitLossCalculated &&
                   IsBranchSpecificCalculated == bilanco.IsBranchSpecificCalculated;
        }
        return false;
    }

    // GetHashCode metodu
    public override int GetHashCode()
    {
        return HashCode.Combine(ProfitandLoss, IsNetProfitLossCalculated, IsBranchSpecificCalculated);
    }
}
