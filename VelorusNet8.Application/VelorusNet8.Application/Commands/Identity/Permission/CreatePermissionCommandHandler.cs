using MediatR;
using VelorusNet8.Infrastructure.Interface;
using VelorusNet8.Domain.Entities.Aggregates.Identity;
using FluentValidation;

namespace VelorusNet8.Application.Commands.Identity.Permission;

public class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreatePermissionCommand> _validator;
    public CreatePermissionCommandHandler(IUnitOfWork unitOfWork, IValidator<CreatePermissionCommand> validator)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<int> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
    {
        // Doğrulama işlemi
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        // Yeni Permission nesnesi oluştur
        var permission = new VelorusNet8.Domain.Entities.Aggregates.Identity.Permission
        {
            Name = request.Name,
        };

         
        // Permission'ı ekle
        _unitOfWork.Permissions.Add(permission);

        // Değişiklikleri kaydet
        await _unitOfWork.CompleteAsync(cancellationToken);

        // Yeni Permission'un Id'sini geri döndür
        return permission.Id;
    }
}
