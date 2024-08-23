using MediatR;

namespace VelorusNet8.Application.Commands.UserAccount;

public class UpdateUserAccountCommand : IRequest<Unit>
{
    public int UserId { get; }
    public string UserName { get; }
    public string Email { get; }

    public UpdateUserAccountCommand(int userId, string userName, string email)
    {
        UserId = userId;
        UserName = userName;
        Email = email;
    }
}
