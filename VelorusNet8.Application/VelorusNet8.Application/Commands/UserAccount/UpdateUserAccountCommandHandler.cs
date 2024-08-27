using MediatR;
using VelorusNet8.Application.Exception;
using VelorusNet8.Application.Interface;


namespace VelorusNet8.Application.Commands.UserAccount;

public class UpdateUserAccountCommandHandler : IRequestHandler<UpdateUserAccountCommand, Unit>
{
    private readonly IUserAccountService _userAccountService;

    public UpdateUserAccountCommandHandler(IUserAccountService userAccountService)
    {
        _userAccountService = userAccountService;
    }

    public async Task<Unit> Handle(UpdateUserAccountCommand request, CancellationToken cancellationToken)
    {
        var userAccount = await _userAccountService.GetByIdAsync(request.UserId,cancellationToken);

        if (userAccount == null)
        {
           throw new NotFoundException($"UserAccount with ID {request.UserId} not found.");
        }

        userAccount.UpdateUserName(request.UserName);
        userAccount.UpdateEmail(request.Email);
        await _userAccountService.UpdateAsync(userAccount, cancellationToken);

        return Unit.Value;
    }

 
}
