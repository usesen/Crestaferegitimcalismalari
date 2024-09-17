using AutoMapper;
using MediatR;
using VelorusNet8.Application.Commands.AngularDersleri.AngularCustomer;
using VelorusNet8.Application.Interface.AngularDersleri;

namespace VelorusNet8.Application.Service.AngularCustomer;
public class AngularCustomerService : IAngularCustomerService
{
    private readonly IAngularCustomerRepository _angularCustomerRepository;
    private readonly IMapper _mapper;

    public AngularCustomerService(IAngularCustomerRepository angularCustomerRepository, IMapper mapper)
    {
        _angularCustomerRepository = angularCustomerRepository;
        _mapper = mapper;
    }

    // Create AngularCustomer
    public async Task<int> CreateAngularCustomerAsync(CreateAngularCustomerCommand command,CancellationToken cancellationToken)
    {
        var angularCustomer = _mapper.Map<VelorusNet8.Domain.Entities.Aggregates.AngularDersleri.AngularCustomer>(command);
        await _angularCustomerRepository.AddAsync(angularCustomer, cancellationToken);
        return angularCustomer.id;
    }
 
    // Delete AngularCustomer
    public async Task DeleteAngularCustomerAsync(int id , CancellationToken cancellationToken)
    {
        var customer = await _angularCustomerRepository.GetByIdAsync(id,cancellationToken);
        if (customer == null)
        {
            throw new KeyNotFoundException("Customer not found");
        }

        await _angularCustomerRepository.DeleteAsync(customer, cancellationToken);
    }

    // Get AngularCustomer by ID
    public async Task<CreateAngularCustomerCommand?> GetAngularCustomerByIdAsync(int id,CancellationToken cancellationToken)
    {
        var customer = await _angularCustomerRepository.GetByIdAsync(id, cancellationToken);
        return _mapper.Map<CreateAngularCustomerCommand>(customer);
    }

    // Get all AngularCustomers
    public async Task<IEnumerable<CreateAngularCustomerCommand>> GetAllAngularCustomersAsync(CancellationToken cancellationToken)
    {
        var customers = await _angularCustomerRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<CreateAngularCustomerCommand>>(customers);
    }

    public async Task UpdateAngularCustomerAsync(UpdateAngularCustomerCommand command, CancellationToken cancellationToken)
    {

        var existingCustomer = await _angularCustomerRepository.GetByIdAsync(command.id, cancellationToken);
        if (existingCustomer == null)
        {
            throw new KeyNotFoundException("Customer not found");
        }

        _mapper.Map(command, existingCustomer); // Komutla entity'yi güncelle
        await _angularCustomerRepository.UpdateAsync(existingCustomer, cancellationToken);
    }
}


