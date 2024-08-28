using MediatR;

namespace VelorusNet8.Application.Commands.UserAccount;

public class UpdateUserAccountCommand : IRequest<int>
{
    public int UserId { get; }
    public string UserName { get; }
    public string Email { get; }
    public string PasswordHash { get; }
    public bool IsActive { get; }

    public UpdateUserAccountCommand(int userId, string userName, string email,string passwordHash, bool isActive)
    {
        UserId = userId;
        UserName = userName;
        Email = email;
        PasswordHash = passwordHash;
        IsActive = isActive;
    }
}
