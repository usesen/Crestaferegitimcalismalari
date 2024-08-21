namespace VelorusNet8.Domain.Entities.Common.ValueObjects;

public class EmailAddress : ValueObject
{
    public string Address { get; }

    public EmailAddress(string address)
    {
        if (string.IsNullOrWhiteSpace(address) || !address.Contains("@"))
            throw new ArgumentException("Invalid email address");

        Address = address;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Address;

    }

    // Override Equals and GetHashCode for value-based equality
    public override bool Equals(object obj)
    {
        return obj is EmailAddress email && Address == email.Address;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Address);
    }

}
