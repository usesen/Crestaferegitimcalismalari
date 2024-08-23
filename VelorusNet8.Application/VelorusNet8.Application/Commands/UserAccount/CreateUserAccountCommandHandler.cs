using MediatR;
using VelorusNet8.Domain.Entities.Aggregates.Users;
using VelorusNet8.Domain.Repositories;

namespace VelorusNet8.Application.Commands.UserAccount;

public class CreateUserAccountCommandHandler : IRequestHandler<CreateUserAccountCommand, int>
{
    private readonly IUserAccountRepository _userRepository;

    public CreateUserAccountCommandHandler(IUserAccountRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<int> Handle(CreateUserAccountCommand request, CancellationToken cancellationToken)
    {
        var userAccount = new VelorusNet8.Domain.Entities.Aggregates.Users.UserAccount(0,request.UserName, request.Email, HashPassword(request.PasswordHash));

        await _userRepository.CreateAsync(userAccount, cancellationToken);

        return userAccount.UserId;  // Yeni kullanıcının ID'sini döndürür
    }

    private string HashPassword(string password)
    {
        // Şifreyi hashlemek için bir yöntem kullanın
        return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
    }
}
