namespace VelorusNet8.Domain.Entities.Common.ValueObjects;

public class Address : ValueObject
{
    public string Street { get; }
    public string City { get; }
    public string PostalCode { get; }
    public string Country { get; }

    public Address(string street, string city, string postalCode, string country)
    {
        Street = street;
        City = city;
        PostalCode = postalCode;
        Country = country;
    }

    // Override Equals and GetHashCode for value-based equality
    public override bool Equals(object obj)
    {
        return obj is Address address &&
               Street == address.Street &&
               City == address.City &&
               PostalCode == address.PostalCode &&
               Country == address.Country;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return City;
        yield return PostalCode;
        yield return Country;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Street, City, PostalCode, Country);
    }
}