using MediatR;

namespace VelorusNet8.Application.Commands.UserAccount;

public class CreateUserAccountCommand : IRequest<int>  // int burada command sonucunda dönecek değeri temsil eder, örneğin yeni kullanıcının ID'si
{
    public string UserName { get; }
    public string Email { get; }
    public string Password { get; }

    public CreateUserAccountCommand(string userName, string email, string password)
    {
        UserName = userName;
        Email = email;
        Password = password;
    }
}
