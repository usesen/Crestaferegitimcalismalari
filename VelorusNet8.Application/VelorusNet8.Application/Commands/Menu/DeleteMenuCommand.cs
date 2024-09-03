using MediatR;

namespace VelorusNet8.Application.Commands.Menu;

public class DeleteMenuCommand : IRequest<Unit>
{
    public int MenuId { get; set; }

    public DeleteMenuCommand(int menuId)
    {
        MenuId = menuId;
    }
}
