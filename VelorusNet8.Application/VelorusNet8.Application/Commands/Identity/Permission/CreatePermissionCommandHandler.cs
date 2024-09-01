using MediatR;
using VelorusNet8.Infrastructure.Interface;
using FluentValidation;
using VelorusNet8.Application.Interface.Service;
using VelorusNet8.Application.DTOs.Identity.Permission;


namespace VelorusNet8.Application.Commands.Identity.Permission;

public class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreatePermissionCommand> _validator;
    private readonly IPermissionService _permissionService;

    public CreatePermissionCommandHandler(IUnitOfWork unitOfWork, IValidator<CreatePermissionCommand> validator, IPermissionService permissionService)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
        _permissionService = permissionService;
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
        var createPermissionDto = new CreatePermissionDTO
        {
            Name = request.Name
        };

        // PermissionService kullanarak yeni bir Permission oluştur
        var permissionId = await _permissionService.CreatePermissionAsync(createPermissionDto, cancellationToken);

        // Permission'ı ekle
        _unitOfWork.Permissions.Add(permission);

        // Değişiklikleri kaydet
        await _unitOfWork.CompleteAsync(cancellationToken);

        // Yeni Permission'un Id'sini geri döndür
        return permission.Id;
    }
}
