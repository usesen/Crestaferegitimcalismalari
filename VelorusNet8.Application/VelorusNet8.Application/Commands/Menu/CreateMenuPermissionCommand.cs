using MediatR;

namespace VelorusNet8.Application.Commands.Menu;

public class CreateMenuPermissionCommand : IRequest<int>
{
    public string PermissionName { get; set; }
    public string Description { get; set; }
    public int MenuId { get; set; }

    public CreateMenuPermissionCommand(string permissionName, string description, int menuId)
    {
        PermissionName = permissionName;
        Description = description;
        MenuId = menuId;
    }
}
