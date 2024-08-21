namespace VelorusNet8.Domain.Entities.Aggregates.Business.ValueOnject;

public class TaxInformation
{
    public string TaxNumber { get; private set; }  // Vergi Numarası
    public string TaxOffice { get; private set; }  // Vergi Dairesi

    public TaxInformation(string taxNumber, string taxOffice)
    {
        if (string.IsNullOrWhiteSpace(taxNumber) || !IsValidTaxNumber(taxNumber))
        {
            throw new ArgumentException("Geçersiz vergi numarası.", nameof(taxNumber));
        }

        if (string.IsNullOrWhiteSpace(taxOffice))
        {
            throw new ArgumentException("Vergi dairesi boş olamaz.", nameof(taxOffice));
        }

        TaxNumber = taxNumber;
        TaxOffice = taxOffice;
    }
    private bool IsValidTaxNumber(string taxNumber)
    {
        // Vergi numarasının geçerliliğini kontrol eden basit bir validasyon
        return taxNumber.Length == 10 && taxNumber.All(char.IsDigit);
    }

    public override bool Equals(object obj)
    {
        if (obj == null || obj.GetType() != typeof(TaxInformation))
            return false;

        var other = (TaxInformation)obj;
        return TaxNumber == other.TaxNumber && TaxOffice == other.TaxOffice;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(TaxNumber, TaxOffice);
    }

    public override string ToString()
    {
        return $"Tax Number: {TaxNumber}, Tax Office: {TaxOffice}";
    }

    public string GetMaskedTaxNumber()
    {
        // Vergi numarasının son 4 hanesi dışında geri kalanını gizleyerek gösterir
        if (TaxNumber.Length < 4)
            return TaxNumber;

        return new string('*', TaxNumber.Length - 4) + TaxNumber.Substring(TaxNumber.Length - 4);
    }
}