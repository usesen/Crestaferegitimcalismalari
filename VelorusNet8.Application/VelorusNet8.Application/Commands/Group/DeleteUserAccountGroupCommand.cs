using MediatR;

namespace VelorusNet8.Application.Commands.Group;

public class DeleteUserAccountGroupCommand : IRequest<Unit>
{
    public int UserAccountGroupId { get; set; }

    public DeleteUserAccountGroupCommand(int userAccountGroupId)
    {
        UserAccountGroupId = userAccountGroupId;
    }
}
