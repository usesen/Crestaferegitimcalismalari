using VelorusNet8.Domain.Entities.Aggregates.Users;
using VelorusNet8.Domain.Entities.Common;
using VelorusNet8.Domain.Entities.Common.ValueObjects;

public class Customer : EntityBase
{
    public int Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public EmailAddress Emails { get; private set; }
    public Address Address { get; private set; }
    

    public Customer(int id, string firstName, string lastName, EmailAddress email, Address address, int userId ) : base(userId)    
    {
        Id = id;
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        Emails = email ?? throw new ArgumentNullException(nameof(email));
        Address = address ?? throw new ArgumentNullException(nameof(address));
    }

    public void UpdateEmail(EmailAddress newEmail)
    {
        Emails = newEmail;
    }

    public void UpdateAddress(Address newAddress)
    {
        Address = newAddress;
    }
    public void ChangeEmail(EmailAddress newEmail)
    {
        Emails = newEmail ?? throw new ArgumentNullException(nameof(newEmail));
    }

    public void ChangeAddress(Address newAddress)
    {
        Address = newAddress ?? throw new ArgumentNullException(nameof(newAddress));
    }


    public override bool Equals(object obj)
    {
        return obj is Customer customer && Id == customer.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
