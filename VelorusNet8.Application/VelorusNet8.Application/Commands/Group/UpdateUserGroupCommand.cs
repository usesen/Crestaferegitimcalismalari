using MediatR;

namespace VelorusNet8.Application.Commands.Group;

public class UpdateUserGroupCommand : IRequest<int>
{
    public int Id { get; set; }  // Güncellenen kullanıcı grubunun kimliği
    public string Name { get; set; }
    public List<int> MenuIds { get; set; } // MenuIds bir liste olmalı

    public UpdateUserGroupCommand(int id, string name, List<int> menuIds)
    {
        Id = id;
        Name = name;
        MenuIds = menuIds ?? new List<int>();
    }
}
