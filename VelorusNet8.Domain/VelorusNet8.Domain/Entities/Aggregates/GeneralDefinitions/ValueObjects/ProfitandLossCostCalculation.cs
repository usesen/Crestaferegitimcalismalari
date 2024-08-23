namespace VelorusNet8.Domain.Entities.Aggregates.GeneralDefinitions.ValueObjects;

public  class ProfitandLossCostCalculation //Kar Zarar - Maliyet Hesabı
{
    public int Id { get; set; }
    public bool IsLIFO { get; private set; } // Yeniden Eskiye (LIFO)
    public bool IsFIFO { get; private set; } // Eskiden Yeniye (FIFO)
    public bool IsVATIncluded { get; private set; } // KDVli Hesaplansın

    // Constructor
    public ProfitandLossCostCalculation(bool isLIFO, bool isFIFO, bool isVATIncluded, int id)
    {
        IsLIFO = isLIFO;
        IsFIFO = isFIFO;
        IsVATIncluded = isVATIncluded;
        Id = id;
    }

    // Equals metodu
    public override bool Equals(object obj)
    {
        if (obj is ProfitandLossCostCalculation calculation)
        {
            return Id == calculation.Id && 
                   IsLIFO == calculation.IsLIFO &&
                   IsFIFO == calculation.IsFIFO &&
                   IsVATIncluded == calculation.IsVATIncluded;
        }
        return false;
    }

    // GetHashCode metodu
    public override int GetHashCode()
    {
        return HashCode.Combine(IsLIFO, IsFIFO, IsVATIncluded);
    }
}
