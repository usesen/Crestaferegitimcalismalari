using FluentValidation;
using MediatR;
using VelorusNet8.Application.Interface.Menus;

namespace VelorusNet8.Application.Commands.Menu;

public class DeleteMenuPermissionCommandHandler : IRequestHandler<DeleteMenuPermissionCommand, Unit>
{
    private readonly IMenuPermissionRepository _menuPermissionRepository;
    private readonly IValidator<DeleteMenuPermissionCommand> _validator;

    public DeleteMenuPermissionCommandHandler(IMenuPermissionRepository menuPermissionRepository, IValidator<DeleteMenuPermissionCommand> validator)
    {
        _menuPermissionRepository = menuPermissionRepository;
        _validator = validator;
    }

    public async Task<Unit> Handle(DeleteMenuPermissionCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        await _menuPermissionRepository.DeleteAsync(request.MenuPermissionId, cancellationToken);

        return Unit.Value;
    }
}