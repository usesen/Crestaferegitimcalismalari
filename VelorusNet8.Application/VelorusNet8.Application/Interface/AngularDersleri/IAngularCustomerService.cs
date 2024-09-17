using VelorusNet8.Application.Commands.AngularDersleri.AngularCustomer;
using VelorusNet8.Application.DTOs.AngularDersleri;
using VelorusNet8.Domain.Entities.Aggregates.AngularDersleri;

namespace VelorusNet8.Application.Interface.AngularDersleri;

public  interface  IAngularCustomerService
{
    Task<int> CreateAngularCustomerAsync(CreateAngularCustomerCommand command,CancellationToken cancellationToken);
    Task UpdateAngularCustomerAsync(UpdateAngularCustomerCommand command,CancellationToken cancellationToken);
    Task DeleteAngularCustomerAsync(int id,CancellationToken cancellationToken);
    Task<CreateAngularCustomerCommand?> GetAngularCustomerByIdAsync(int id,CancellationToken cancellationToken);
    Task<IEnumerable<CreateAngularCustomerCommand>> GetAllAngularCustomersAsync(CancellationToken cancellationToken);
}
