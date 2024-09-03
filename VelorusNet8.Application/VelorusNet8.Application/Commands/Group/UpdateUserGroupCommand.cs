using MediatR;
using VelorusNet8.Application.DTOs.Group;

namespace VelorusNet8.Application.Commands.Group;

public class UpdateUserGroupCommand : IRequest<int>
{
    public int Id { get; set; }  // Güncellenen kullanıcı grubunun kimliği
    public string Name { get; set; }
    public List<int> MenuIds { get; set; } // MenuIds bir liste olmalı
    public List<UserGroupPermissionDto> Permissions { get; set; }

    public UpdateUserGroupCommand(int id, string name, List<int> menuIds, List<UserGroupPermissionDto> permissions)
    {
        Id = id;
        Name = name;
        MenuIds = menuIds ?? new List<int>();
        Permissions = permissions;
    }
}
