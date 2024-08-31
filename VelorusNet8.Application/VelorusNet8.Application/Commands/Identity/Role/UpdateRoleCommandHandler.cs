using FluentValidation;
using MediatR;
using VelorusNet8.Infrastructure.Interface;

namespace VelorusNet8.Application.Commands.Identity.Role;

public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly IValidator<UpdateRoleCommand> _validator;

    public UpdateRoleCommandHandler(IValidator<UpdateRoleCommand> validator, IUnitOfWork unitOfWork)
    {
        _validator = validator;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
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
