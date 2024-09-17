using VelorusNet8.Domain.Entities.Aggregates.AngularDersleri;

namespace VelorusNet8.Application.Interface.AngularDersleri;

public interface IAngularCustomerRepository
{
    Task<AngularCustomer> GetByIdAsync(int id,CancellationToken cancellationToken);
    Task<IEnumerable<AngularCustomer>> GetAllAsync(CancellationToken cancellationToken);
    Task AddAsync(AngularCustomer angularCustomer,CancellationToken cancellationToken);
    Task UpdateAsync(AngularCustomer angularCustomer, CancellationToken cancellationToken);
    Task DeleteAsync(AngularCustomer angularCustomer, CancellationToken cancellationToken);
}
