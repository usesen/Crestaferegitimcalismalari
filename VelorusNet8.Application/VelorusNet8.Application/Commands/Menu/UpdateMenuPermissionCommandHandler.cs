using FluentValidation;
using MediatR;
using VelorusNet8.Application.Interface.Menus;

namespace VelorusNet8.Application.Commands.Menu;

public class UpdateMenuPermissionCommandHandler : IRequestHandler<UpdateMenuPermissionCommand, Unit>
{
    private readonly IMenuPermissionRepository _menuPermissionRepository;
    private readonly IValidator<UpdateMenuPermissionCommand> _validator;

    public UpdateMenuPermissionCommandHandler(IMenuPermissionRepository menuPermissionRepository, IValidator<UpdateMenuPermissionCommand> validator)
    {
        _menuPermissionRepository = menuPermissionRepository;
        _validator = validator;
    }

    public async Task<Unit> Handle(UpdateMenuPermissionCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var menuPermission = await _menuPermissionRepository.GetByIdAsync(request.MenuPermissionId, cancellationToken);

        if (menuPermission == null)
        {
            throw new KeyNotFoundException("MenuPermission not found.");
        }

        menuPermission.MenuId = request.MenuId;
        menuPermission.UserAccountId = request.UserAccountId;
        menuPermission.GroupId = request.GroupId;
        menuPermission.CanView = request.CanView;
        menuPermission.CanEdit = request.CanEdit;
        menuPermission.CanDelete = request.CanDelete;
        menuPermission.CanExcel = request.CanExcel;
        menuPermission.CanPdf = request.CanPdf;
        menuPermission.CanWord = request.CanWord;

        await _menuPermissionRepository.UpdateAsync(menuPermission, cancellationToken);

        return Unit.Value;
    }
}