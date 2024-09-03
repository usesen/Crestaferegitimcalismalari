using MediatR;

namespace VelorusNet8.Application.Commands.Menu;

public class DeleteMenuPermissionCommand : IRequest<Unit>
{
    public int MenuPermissionId { get; set; }  // Benzersiz kimlik

    public DeleteMenuPermissionCommand(int menuPermissionId)
    {
        MenuPermissionId = menuPermissionId;
    }
}
