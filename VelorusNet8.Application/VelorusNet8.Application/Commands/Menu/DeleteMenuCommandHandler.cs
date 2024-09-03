using FluentValidation;
using MediatR;
using VelorusNet8.Application.Exception;
using VelorusNet8.Application.Interface.Group;

namespace VelorusNet8.Application.Commands.Menu;

public class DeleteMenuCommandHandler : IRequestHandler<DeleteMenuCommand, Unit>
{
    private readonly IMenuRepository _menuRepository;
    private readonly IValidator<DeleteMenuCommand> _validator;
    public DeleteMenuCommandHandler(IMenuRepository menuRepository, IValidator<DeleteMenuCommand> validator)
    {
        _menuRepository = menuRepository;
        _validator = validator;
    }

    public async Task<Unit> Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new FluentValidation.ValidationException(validationResult.Errors);
        }
        var existingMenu = await _menuRepository.GetByIdAsync(request.MenuId, cancellationToken);

        if (existingMenu == null)
        {
            throw new NotFoundException(nameof(Menu) + " " +  request.MenuId);
        }

        await _menuRepository.DeleteAsync(request.MenuId, cancellationToken);

        return Unit.Value;
    }
}
