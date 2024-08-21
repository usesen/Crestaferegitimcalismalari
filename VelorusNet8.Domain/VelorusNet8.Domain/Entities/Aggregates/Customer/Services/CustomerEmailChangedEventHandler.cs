using VelorusNet8.Domain.Entities.Aggregates.Customer.Events;
using VelorusNet8.Domain.Entities.Common.Interfaces;

namespace VelorusNet8.Domain.Entities.Aggregates.Customer.Services;

public class CustomerEmailChangedEventHandler : IDomainEventHandler<EmailChangedEvent>
{
    public void Handle(EmailChangedEvent domainEvent)
    {
        // Burada domain event işleme mantığını ekleyebilirsiniz.
        Console.WriteLine($"Email changed from {domainEvent.OldEmail} to {domainEvent.NewEmail}");
    }
}
