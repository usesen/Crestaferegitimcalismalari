using AutoMapper;
using FluentValidation;
using MediatR;
using VelorusNet8.Application.Interface.AngularDersleri;
using VelorusNet8.Domain.Entities.Aggregates.AngularDersleri;

namespace VelorusNet8.Application.Commands.AngularDersleri.AngularCustomer;

public class CreateAngularCustomerCommandHandler : IRequestHandler<CreateAngularCustomerCommand, int>
{
    private readonly IAngularCustomerRepository _angularCustomerRepository;
    private readonly IValidator<CreateAngularCustomerCommand> _validator;
    private readonly IMapper _mapper;

    public CreateAngularCustomerCommandHandler(IAngularCustomerRepository angularCustomerRepository, IValidator<CreateAngularCustomerCommand> validator, IMapper mapper)
    {
        _angularCustomerRepository = angularCustomerRepository;
        _validator = validator;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateAngularCustomerCommand request, CancellationToken cancellationToken)
    {
        // Doğrulama işlemi
        // AngularCustomer entity'sini service katmanı ile güncelle
        var angularCustomer = await _angularCustomerRepository.GetByIdAsync(request.id, cancellationToken);

        if (angularCustomer != null)
        {
            return 0;
        }

        // Command'dan AngularCustomer entity'sine mapleme işlemi
        angularCustomer = _mapper.Map<VelorusNet8.Domain.Entities.Aggregates.AngularDersleri.
            AngularCustomer>(request);

        // AngularCustomerService kullanarak entity'yi güncelle
        await _angularCustomerRepository.AddAsync(angularCustomer, cancellationToken);

        return angularCustomer.id; // Güncellenen müşteri ID'sini döndür

 
    }
}

