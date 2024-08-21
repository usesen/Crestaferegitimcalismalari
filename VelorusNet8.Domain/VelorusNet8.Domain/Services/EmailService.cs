using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelorusNet8.Domain.Entities.Aggregates.Customer.Events;
using VelorusNet8.Domain.Entities.Common.Interfaces;
using VelorusNet8.Domain.Entities.Common.ValueObjects;

namespace VelorusNet8.Domain.Services;

public class EmailService
{
    private readonly IDomainEventHandler<EmailChangedEvent> _emailChangedEventHandler;

    public EmailService(IDomainEventHandler<EmailChangedEvent> emailChangedEventHandler)
    {
        _emailChangedEventHandler = emailChangedEventHandler;
    }

    public void ChangeCustomerEmail(Customer customer, EmailAddress newEmail)
    {
        var oldEmail = customer.Emails.Address;
        customer.UpdateEmail(newEmail);

        var emailChangedEvent = new EmailChangedEvent(oldEmail, newEmail.Address);
        _emailChangedEventHandler.Handle(emailChangedEvent);
    }
}
