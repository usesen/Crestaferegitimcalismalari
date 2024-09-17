using AutoMapper;
using FluentValidation;
using MediatR;
using VelorusNet8.Application.Exception;
using VelorusNet8.Application.Interface.AngularDersleri;

namespace VelorusNet8.Application.Commands.AngularDersleri.AngularCustomer;

public class UpdateAngularCustomerCommandHandler : IRequestHandler<UpdateAngularCustomerCommand, int>
{
    private readonly IAngularCustomerRepository _angularCustomerRepository;
    private readonly IValidator<UpdateAngularCustomerCommand> _validator;
    private readonly IMapper _mapper;

    public UpdateAngularCustomerCommandHandler(IAngularCustomerRepository angularCustomerRepository, IValidator<UpdateAngularCustomerCommand> validator, IMapper mapper)
    {
        _angularCustomerRepository = angularCustomerRepository;
        _validator = validator;
        _mapper = mapper;
    }
    public async Task<int> Handle(UpdateAngularCustomerCommand request, CancellationToken cancellationToken)
    {
        // Doğrulama işlemi
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
        {
            // Hataları topluyoruz
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

            // Hataları bir exception veya response nesnesi olarak döndürebilirsiniz
            throw new FluentValidation.ValidationException(validationResult.Errors);
        }
        // Veritabanında Customer'ı bul
        var angularCustomer = await _angularCustomerRepository.GetByIdAsync(request.id, cancellationToken);

        if (angularCustomer == null)
        {
            // Eğer customer bulunamazsa, hata döndür
            throw new NotFoundException(nameof(AngularCustomer) + " " + request.id.ToString());
        }

        // Customer bilgilerini güncelle
        angularCustomer = _mapper.Map<VelorusNet8.Domain.Entities.Aggregates.AngularDersleri.AngularCustomer>(request);


        angularCustomer.LastModifiedBy = "Uğur Şeşen";
        angularCustomer.LastModifiedDate= DateTime.UtcNow;
        angularCustomer.CreatedBy = "Uğur Şeşen";
        // Veritabanında güncelle
        await _angularCustomerRepository.UpdateAsync(angularCustomer, cancellationToken);

        // Güncellenen kullanıcının ID'sini döndür
        return angularCustomer.id;
    }
}

