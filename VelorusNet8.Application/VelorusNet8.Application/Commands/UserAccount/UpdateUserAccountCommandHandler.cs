using FluentValidation;
using MediatR;
using VelorusNet8.Application.Exception;
using VelorusNet8.Application.Interface;
using ValidationException = FluentValidation.ValidationException;


namespace VelorusNet8.Application.Commands.UserAccount;

public class UpdateUserAccountCommandHandler : IRequestHandler<UpdateUserAccountCommand, int>
{
    private readonly IUserAccountRepository _userAccountRepository;
    private readonly IValidator<UpdateUserAccountCommand> _validator;

    public UpdateUserAccountCommandHandler(IUserAccountRepository userAccountRepository, IValidator<UpdateUserAccountCommand> validator)
    {
        _userAccountRepository = userAccountRepository;
        _validator = validator;
    }

    public async Task<int> Handle(UpdateUserAccountCommand request, CancellationToken cancellationToken)
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
        // Veritabanında UserAccount'u bul
        var userAccount = await _userAccountRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (userAccount == null)
        {
            // Eğer kullanıcı bulunamazsa, hata döndür
            throw new NotFoundException(nameof(UserAccount) + " " + request.UserId.ToString());
        }

        // Kullanıcı bilgilerini güncelle
        userAccount.UpdateUserName(request.UserName);
        userAccount.UpdateEmail(request.Email);
        userAccount.IsActive = request.IsActive;

        // Veritabanında güncelle
        await _userAccountRepository.UpdateAsync(userAccount, cancellationToken);

        // Güncellenen kullanıcının ID'sini döndür
        return userAccount.UserId;
    }

 
}
