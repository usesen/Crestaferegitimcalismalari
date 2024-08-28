using AutoMapper;
using FluentValidation;
using MediatR;
using VelorusNet8.Application.Commands.UserAccount;
using VelorusNet8.Application.Dto.User;
using VelorusNet8.Application.Interface;

namespace VelorusNet8.Application.Commands.UserAccount;

public class CreateUserAccountCommandHandler : IRequestHandler<CreateUserAccountCommand, int>
{
    private readonly IUserAccountRepository _userAccountRepository;
    private readonly IValidator<CreateUserAccountCommand> _validator;
    public CreateUserAccountCommandHandler(IUserAccountRepository userAccountRepository, IValidator<CreateUserAccountCommand> validator)
    {
        _userAccountRepository = userAccountRepository;
        _validator = validator;
    }

    public async Task<int> Handle(CreateUserAccountCommand request, CancellationToken cancellationToken)
    {
        // Doğrulama işlemi
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
        {
            // Hataları topluyoruz
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

            // Hataları bir exception veya response nesnesi olarak döndürebilirsiniz
            throw new ValidationException(validationResult.Errors);
        }
        var userAccount = new VelorusNet8.Domain.Entities.Aggregates.Users.UserAccount(0,
            request.UserName,
            request.Email,
            request.PasswordHash,
            request.IsActive
        );

        // UserAccount nesnesini veritabanına kaydet
        await _userAccountRepository.AddAsync(userAccount, cancellationToken);

        // Yeni oluşturulan kullanıcı ID'sini geri döndür
        return userAccount.UserId;

    }

    private string HashPassword(string password)
    {
        // Şifreyi hashlemek için bir yöntem kullanın
        return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
    }
 
}
