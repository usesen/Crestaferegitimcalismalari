using VelorusNet8.Domain.Entities.Aggregates.Customer.Events;
using VelorusNet8.Domain.Entities.Common.Interfaces;

namespace VelorusNet8.Domain.Entities.Aggregates.Customer.Services;
public class CustomerAddressChangedEventHandler : IDomainEventHandler<AddressChangedEvent>
{
    public void Handle(AddressChangedEvent domainEvent)
    {
        Console.WriteLine($"Address changed from {domainEvent.OldAddress.Street}, {domainEvent.OldAddress.City} to {domainEvent.NewAddress.Street}, {domainEvent.NewAddress.City}");
    }
}