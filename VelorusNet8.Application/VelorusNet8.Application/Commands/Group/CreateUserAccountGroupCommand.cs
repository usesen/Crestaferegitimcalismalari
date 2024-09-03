using MediatR;

namespace VelorusNet8.Application.Commands.Group;

public class CreateUserAccountGroupCommand : IRequest<int>
{
    public int UserId { get; set; }
    public int GroupId { get; set; }

    public CreateUserAccountGroupCommand(int userId, int groupId)
    {
        UserId = userId;
        GroupId = groupId;
    }
}
