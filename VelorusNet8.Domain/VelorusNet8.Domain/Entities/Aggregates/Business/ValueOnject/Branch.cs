using VelorusNet8.Domain.Entities.Common.ValueObjects;

namespace VelorusNet8.Domain.Entities.Aggregates.Business.ValueOnject;

public class Branch
{
    public string BranchName { get; private set; }  // Şube Adı
    public string BranchCode { get; private set; }  // Şube Kodu
    public Address BranchAddress { get; private set; }  // Şube Adresi

    public Branch(string branchName, string branchCode, Address branchAddress)
    {
        if (string.IsNullOrWhiteSpace(branchName))
        {
            throw new ArgumentException("Şube adı boş olamaz.", nameof(branchName));
        }

        if (string.IsNullOrWhiteSpace(branchCode))
        {
            throw new ArgumentException("Şube kodu boş olamaz.", nameof(branchCode));
        }

        if (branchAddress == null)
        {
            throw new ArgumentNullException(nameof(branchAddress), "Şube adresi null olamaz.");
        }

        BranchName = branchName;
        BranchCode = branchCode;
        BranchAddress = branchAddress;
    }
    public override bool Equals(object obj)
    {
        if (obj == null || obj.GetType() != typeof(Branch))
            return false;

        var other = (Branch)obj;
        return BranchName == other.BranchName && BranchCode == other.BranchCode && BranchAddress.Equals(other.BranchAddress);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(BranchName, BranchCode, BranchAddress);
    }

    public override string ToString()
    {
        return $"Branch: {BranchName} (Code: {BranchCode}), Address: {BranchAddress}";
    }

    public string GetFormattedAddress()
    {
        return BranchAddress.ToString();
    }
}
