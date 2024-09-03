using MediatR;
using VelorusNet8.Application.Exception;
using VelorusNet8.Application.Interface.Group;

namespace VelorusNet8.Application.Commands.Menu;

public class DeleteMenuCommandHandler : IRequestHandler<DeleteMenuCommand, Unit>
{
    private readonly IMenuRepository _menuRepository;

    public DeleteMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<Unit> Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
    {
        var existingMenu = await _menuRepository.GetByIdAsync(request.MenuId, cancellationToken);

        if (existingMenu == null)
        {
            throw new NotFoundException(nameof(Menu) + " " +  request.MenuId);
        }

        await _menuRepository.DeleteAsync(request.MenuId, cancellationToken);

        return Unit.Value;
    }
}
