using MediatR;
using VelorusNet8.Application.DTOs.Menu;

namespace VelorusNet8.Application.Commands.Menu;

public class CreateMenuCommand : IRequest<int>
{
    public string Title { get; set; }
    public string Icon { get; set; }
    public string Url { get; set; }
    public int? ParentMenuId { get; set; }
    public List<MenuPermissionDto> MenuPermissions { get; set; }

    public CreateMenuCommand()
    {
        MenuPermissions = new List<MenuPermissionDto>();
    }
}

