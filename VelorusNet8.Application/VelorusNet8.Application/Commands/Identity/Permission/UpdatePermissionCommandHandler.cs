using FluentValidation;
using MediatR;
using VelorusNet8.Application.Commands.Identity.Permission;
using VelorusNet8.Infrastructure.Interface;

namespace VelorusNet8.Application.Commands.Identity.PermissionRepository;

public class UpdatePermissionCommandHandler : IRequestHandler<UpdatePermissionCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdatePermissionCommand> _validator;

    public UpdatePermissionCommandHandler(IValidator<UpdatePermissionCommand> validator, IUnitOfWork unitOfWork)
    {
        _validator = validator;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
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
