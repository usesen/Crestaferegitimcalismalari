
using VelorusNet8.Domain.Entities.Aggregates.Customer.Events;
using VelorusNet8.Domain.Entities.Aggregates.Customer.Services;
using VelorusNet8.Domain.Entities.Common.Interfaces;
using VelorusNet8.Domain.Entities.Common.ValueObjects;

namespace VelorusNet8.Domain.Services;

public class AddressService
{
    private readonly IDomainEventHandler<AddressChangedEvent> _addressChangedEventHandler;

    public AddressService(CustomerEmailChangedEventHandler emailChangedEventHandler, IDomainEventHandler<AddressChangedEvent> addressChangedEventHandler)
    {
        _addressChangedEventHandler = addressChangedEventHandler;
    }
    public void ChangeCustomerAddress(Customer customer, Address newAddress)
    {
        var oldAddress = customer.Address;
        customer.ChangeAddress(newAddress);

        var addressChangedEvent = new AddressChangedEvent(oldAddress, newAddress);
        _addressChangedEventHandler.Handle(addressChangedEvent);
    }
}
