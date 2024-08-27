using MediatR;
using VelorusNet8.Application.Dto.User;

namespace VelorusNet8.Application.Commands.UserAccount;

public class CreateUserAccountCommand : IRequest<CreateUserAccountDto>  // int burada command sonucunda dönecek değeri temsil eder, örneğin yeni kullanıcının ID'si
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public bool IsActive{ get; set; }
    public CreateUserAccountCommand(int id, string userName, string email,  string passwordHash, bool isActive)
    {
        Id = id;
        UserName = userName;
        Email = email;
        IsActive = isActive;
        PasswordHash = passwordHash;
         
    }
}
