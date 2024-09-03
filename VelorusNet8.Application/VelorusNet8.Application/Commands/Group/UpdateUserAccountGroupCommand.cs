namespace VelorusNet8.Application.Commands.Group;

using MediatR;

public class UpdateUserAccountGroupCommand : IRequest<Unit>
{
    public int UserAccountGroupId { get; set; }
    public int UserId { get; set; }
    public int GroupId { get; set; }

    public UpdateUserAccountGroupCommand(int userAccountGroupId, int userId, int groupId)
    {
        UserAccountGroupId = userAccountGroupId;
        UserId = userId;
        GroupId = groupId;
    }
}

