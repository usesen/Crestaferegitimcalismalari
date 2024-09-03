using MediatR;

namespace VelorusNet8.Application.Commands.Group;

public class DeleteUserGroupCommand : IRequest<Unit>
{
    public int Id { get; set; }

    public DeleteUserGroupCommand(int id)
    {
        Id = id;
    }
}
