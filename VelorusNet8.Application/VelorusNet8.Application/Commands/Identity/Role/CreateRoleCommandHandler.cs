using FluentValidation;
using MediatR;
using VelorusNet8.Application.DTOs.Identity.Role;
using VelorusNet8.Application.Interface.Service;
using VelorusNet8.Infrastructure.Interface;

namespace VelorusNet8.Application.Commands.Identity.Role;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRoleService _roleService;
    private readonly IValidator<CreateRoleCommand> _validator;

    public CreateRoleCommandHandler(IUnitOfWork unitOfWork, IValidator<CreateRoleCommand> validator, IRoleService roleService)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
        _roleService = roleService;
    }


    public async Task<int> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        // Validation işlemi
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var createRoleDto = new CreateRoleDTO
        {
            Name = request.Name
        };

        // RoleService kullanarak yeni bir Role oluştur
        var roleId = await _roleService.CreateRoleAsync(createRoleDto, cancellationToken);

        // UnitOfWork ile transaction işlemi
        await _unitOfWork.CompleteAsync(cancellationToken);

        return roleId;
    }
}
