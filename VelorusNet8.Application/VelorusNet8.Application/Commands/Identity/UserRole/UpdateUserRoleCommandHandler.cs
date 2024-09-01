using FluentValidation;
using MediatR;
using VelorusNet8.Application.Dtos.Identity.UserRole;
using VelorusNet8.Application.Interface.Service;
using VelorusNet8.Infrastructure.Interface;

namespace VelorusNet8.Application.Commands.Identity.UserRole;

public class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommand, bool>
{
    private readonly IUserRoleService _userRoleService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<UpdateUserRoleCommand> _validator;

    public UpdateUserRoleCommandHandler(
        IUserRoleService userRoleService,
        IUnitOfWork unitOfWork,
        IValidator<UpdateUserRoleCommand> validator)
    {
        _userRoleService = userRoleService;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<bool> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
    {
        // Validation işlemi
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var updateUserRoleDto = new UpdateUserRoleDTO
        {
            UserId = request.UserId,
            RoleId = request.RoleId
        };

        var result = await _userRoleService.UpdateUserRoleAsync(request.Id, updateUserRoleDto, cancellationToken);

        // UnitOfWork ile transaction işlemi
        await _unitOfWork.CompleteAsync(cancellationToken);

        return result;
    }
}