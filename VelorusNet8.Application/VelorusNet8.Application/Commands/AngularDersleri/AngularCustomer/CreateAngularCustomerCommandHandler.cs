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

        if (angularCustomer == null)
        {
            return 0;
        }

        // Gelen Command'den entity'nin bilgilerini güncelle
        angularCustomer.id = request.id;
        angularCustomer.firstName = request.firstName;
        angularCustomer.lastName = request.lastName;
        angularCustomer.email = request.email;
        angularCustomer.phone = request.phone;
        angularCustomer.address = request.address;
        angularCustomer.city = request.city;
        angularCustomer.country = request.country;
        angularCustomer.postalCode = request.postalCode;
        angularCustomer.company = request.company;
        angularCustomer.position = request.position;
        angularCustomer.notes = request.notes;
        angularCustomer.IsActive = request.IsActive;
        angularCustomer.Debt = request.Debt;
        angularCustomer.Credit = request.Credit;
        angularCustomer.BalanceDebt = request.BalanceDebt;  
        angularCustomer.BalanceCredit = request.BalanceCredit;


        // AngularCustomerService kullanarak entity'yi güncelle
        await _angularCustomerRepository.UpdateAsync(angularCustomer, cancellationToken);

        return angularCustomer.id; // Güncellenen müşteri ID'sini döndür

 
    }
}

