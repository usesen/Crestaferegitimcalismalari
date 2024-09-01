using FluentValidation;
using MediatR;
using VelorusNet8.Application.Commands.Identity.Permission;
using VelorusNet8.Application.Dto.Identity.Permission.PermissionDTO;
using VelorusNet8.Application.Interface.Service;
using VelorusNet8.Infrastructure.Interface;

namespace VelorusNet8.Application.Commands.Identity.PermissionRepository;

public class UpdatePermissionCommandHandler : IRequestHandler<UpdatePermissionCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdatePermissionCommand> _validator;
    private readonly IPermissionService _permissionService;

    public UpdatePermissionCommandHandler(IValidator<UpdatePermissionCommand> validator, IUnitOfWork unitOfWork, IPermissionService permissionService)
    {
        _validator = validator;
        _unitOfWork = unitOfWork;
        _permissionService = permissionService;
    }

    public async Task<bool> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
    {
        // Doğrulama işlemi
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        // DTO'yu oluştur
        var updatePermissionDto = new UpdatePermissionDTO
        {
            Name = request.Name
        };

        // PermissionService kullanarak mevcut Permission'ı güncelle
        var isUpdated = await _permissionService.UpdatePermissionAsync(request.Id, updatePermissionDto, cancellationToken);

        if (!isUpdated)
        {
            return false;
        }

        // Değişiklikleri kaydet
        await _unitOfWork.CompleteAsync(cancellationToken);

        return true;
    }
}
