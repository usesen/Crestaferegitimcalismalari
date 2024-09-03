using MediatR;

namespace VelorusNet8.Application.Commands.Group;

public class CreateUserGroupCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<int> PermissionIds { get; set; }

    public CreateUserGroupCommand(string name, string description, ICollection<int> permissionIds)
    {
        Name = name;
        Description = description;
        PermissionIds = permissionIds ?? new List<int>();
    }
}
