namespace VelorusNet8.Domain.Entities.Aggregates.Customer.Events;

public class EmailChangedEvent
{
    public string OldEmail { get; }
    public string NewEmail { get; }

    public EmailChangedEvent(string oldEmail, string newEmail)
    {
        OldEmail = oldEmail;
        NewEmail = newEmail;
    }
}
