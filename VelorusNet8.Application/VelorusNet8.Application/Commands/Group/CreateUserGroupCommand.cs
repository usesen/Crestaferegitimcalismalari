using MediatR;
using VelorusNet8.Application.DTOs.Group;

namespace VelorusNet8.Application.Commands.Group;

public class CreateUserGroupCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<UserGroupPermissionDto> Permissions { get; set; }  // Bu özellik eklenmeli

    public CreateUserGroupCommand(string name, string description, ICollection<int> permissionIds)
    {
        Name = name;
        Description = description;
        permissionIds = permissionIds ?? new List<int>();
    }
}
