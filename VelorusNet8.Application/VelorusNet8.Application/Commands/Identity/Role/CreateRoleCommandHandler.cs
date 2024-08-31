

using FluentValidation;
using MediatR;
using VelorusNet8.Infrastructure.Interface;

namespace VelorusNet8.Application.Commands.Identity.Role;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly IValidator<CreateRoleCommand> _validator;

    public CreateRoleCommandHandler(IUnitOfWork unitOfWork, IValidator<CreateRoleCommand> validator)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
    }


    public async Task<int> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        // Doğrulama işlemi
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        // Yeni Permission nesnesi oluştur
        var role = new VelorusNet8.Domain.Entities.Aggregates.Identity.Role
        {
            Name = request.Name
        };


        // Permission'ı ekle
        _unitOfWork.Roles.Add(role);

        // Değişiklikleri kaydet
        await _unitOfWork.CompleteAsync(cancellationToken);

        // Yeni Permission'un Id'sini geri döndür
        return role.Id;
    }
}
