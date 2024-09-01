using FluentValidation;
using MediatR;
using VelorusNet8.Application.Exception;
using VelorusNet8.Domain.Entities.Aggregates.Identity;
using VelorusNet8.Infrastructure.Interface;

namespace VelorusNet8.Application.Commands.Identity.RoleRepository;

public class UpdateRolePermissionCommandHandler : IRequestHandler<UpdateRolePermissionCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdateRolePermissionCommand> _validator;

    public UpdateRolePermissionCommandHandler(IUnitOfWork unitOfWork, IValidator<UpdateRolePermissionCommand> validator)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<int> Handle(UpdateRolePermissionCommand request, CancellationToken cancellationToken)
    {
        // Doğrulama işlemi
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new System.ComponentModel.DataAnnotations.ValidationException(validationResult.Errors.ToString());
        }

        // Ekstra kontrol: Role ve Permission'un var olup olmadığını kontrol et
        var role = await _unitOfWork.Roles.GetRoleByIdAsync(request.RoleId, cancellationToken);
        if (role == null)
        {
            throw new NotFoundException($"Role with Id {request.RoleId} not found.");
        }

        var permission = await _unitOfWork.Permissions.GetPermissionByIdAsync(request.PermissionId, cancellationToken);
        if (permission == null)
        {
            throw new NotFoundException($"Permission with Id {request.PermissionId} not found.");
        }

        // Yeni RolePermission nesnesi oluştur
        var rolePermission = new VelorusNet8.Domain.Entities.Aggregates.Identity.RolePermission
        {
            RoleId = request.RoleId,
            PermissionId = request.PermissionId
        };

        // RolePermission'ı ekle
        _unitOfWork.RolePermissions.Add(rolePermission);

        // Değişiklikleri kaydet
        await _unitOfWork.CompleteAsync(cancellationToken);

        // Yeni RolePermission'un Id'sini geri döndür
        return rolePermission.Id;
    }

 
}
