
namespace VelorusNet8.Domain.Entities.Common.Interfaces;

public interface IDomainEventHandler<in T> where T : class
{
    void Handle(T domainEvent);
}