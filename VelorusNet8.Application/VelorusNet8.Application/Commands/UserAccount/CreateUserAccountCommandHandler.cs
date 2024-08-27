using AutoMapper;
using MediatR;
using VelorusNet8.Application.Commands.UserAccount;
using VelorusNet8.Application.Dto.User;
using VelorusNet8.Application.Interface;

namespace VelorusNet8.Application.Commands.UserAccount;

public class CreateUserAccountCommandHandler : IRequest<int>
{
    private readonly IUserAccountService _iuserAccountService;
    private readonly IMapper _mapper;

    public CreateUserAccountCommandHandler(IUserAccountService iuserAccountService, IMapper mapper)
    {
        _iuserAccountService = iuserAccountService;
        _mapper = mapper;
    }

    public async  Task<int> Handle(CreateUserAccountCommand request, CancellationToken cancellationToken)
    {
        // UserAccount nesnesini oluştur
        var userAccount = new VelorusNet8.Domain.Entities.Aggregates.Users.UserAccount(0, request.UserName, request.Email, request.PasswordHash, request.IsActive);

        var createUserDto = _mapper.Map<CreateUserAccountDto>(userAccount);
        await _iuserAccountService.CreateUserAsync(createUserDto, cancellationToken);
 
        var createdUser = await _iuserAccountService.GetByEmailAsync(request.Email, cancellationToken);
        if (createdUser == null)
        {
            // Kullanıcı oluşturulmadıysa veya bulunmadıysa hata durumu
            return -1;
        }

        // Oluşturulan kullanıcı kimliğini döndür
        return createdUser.UserId;
    }

    private string HashPassword(string password)
    {
        // Şifreyi hashlemek için bir yöntem kullanın
        return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
    }
 
}
