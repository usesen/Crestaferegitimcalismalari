using VelorusNet8.Domain.Entities.Aggregates.Users;
using VelorusNet8.Domain.Entities.Common.ValueObjects;

namespace VelorusNet8.Domain.Services;

public class CustomerService
{
 

    public void RegisterNewCustomer(int id, string firstName, string lastName, EmailAddress email, Address address,int userId) 
    {
        var customer = new Customer(id, firstName, lastName, email, address,userId);
        // Business logic for registering a new customer
    }

    public void ChangeCustomerAddress(Customer customer, Address newAddress)
    {
        customer.UpdateAddress(newAddress);
        // Additional domain logic
    }
}
