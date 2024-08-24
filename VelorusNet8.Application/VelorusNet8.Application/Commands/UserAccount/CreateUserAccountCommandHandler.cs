using AutoMapper;
using MediatR;
using VelorusNet8.Domain.Entities.Aggregates.Users;
using VelorusNet8.Domain.Services.UserAccountService;

namespace VelorusNet8.Application.Commands.UserAccountDto;

public class CreateUserAccountCommandHandler : IRequestHandler<CreateUserAccountCommand, int>
{
    private readonly IUserAccountDomainService _userAccountDomainService;
    private readonly IMapper _mapper;

    public CreateUserAccountCommandHandler(IUserAccountDomainService userAccountDomainService, IMapper mapper)
    {
        _userAccountDomainService = userAccountDomainService;
        _mapper = mapper;
    }

    public async  Task<int> Handle(CreateUserAccountCommand request, CancellationToken cancellationToken)
    {
        var userAccount = new UserAccount(0, request.UserName, request.Email, request.PasswordHash, request.IsActive);

        // Use the IUserAccountDomainService to create the user account.
        await _userAccountDomainService.CreateAsync(userAccount, cancellationToken);
        var createdUser = await _userAccountDomainService.GetByEmailAsync(request.Email, cancellationToken);
        if (createdUser == null)
        {
            // Handle the case where the user creation failed or the user was not found.
            return -1;
        }

        // Return the ID of the created user account.
        return createdUser.UserId;
    }

    private string HashPassword(string password)
    {
        // Şifreyi hashlemek için bir yöntem kullanın
        return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
    }
 
}
