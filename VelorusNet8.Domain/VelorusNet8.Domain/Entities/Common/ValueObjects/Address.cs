namespace VelorusNet8.Domain.Entities.Common.ValueObjects;

public class Address : ValueObject
{
    public string Street { get; private set; }  // Sokak
    public string Neighborhood { get; private set; }  // Mahalle
    public string District { get; private set; }  // İlçe
    public string City { get; private set; }  // Şehir
    public string PostalCode { get; private set; }  // Posta Kodu
    public string Country { get; private set; }  // Ülke

    public Address(string street, string neighborhood, string district, string city, string postalCode, string country)
    {
        Street = street;
        Neighborhood = neighborhood;
        District = district;
        City = city;
        PostalCode = postalCode;
        Country = country;
    }

    // Override Equals and GetHashCode for value-based equality
    public override bool Equals(object obj)
    {
        return obj is Address address &&
               Street == address.Street &&
               Neighborhood == address.Neighborhood &&
               District == address.District &&
               City == address.City &&
               PostalCode == address.PostalCode &&
               Country == address.Country;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return Neighborhood;
        yield return District;
        yield return City;
        yield return PostalCode;
        yield return Country;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Street,Neighborhood,District, City, PostalCode, Country);
    }
}