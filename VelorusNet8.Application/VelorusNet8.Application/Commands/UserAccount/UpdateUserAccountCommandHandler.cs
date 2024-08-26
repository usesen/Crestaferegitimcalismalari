using MediatR;
using VelorusNet8.Application.Exception;
using VelorusNet8.Domain.Repositories;
using VelorusNet8.Domain.Services.UserAccountService;

namespace VelorusNet8.Application.Commands.UserAccountDto;

public class UpdateUserAccountCommandHandler : IRequestHandler<UpdateUserAccountCommand, Unit>
{
    private readonly IUserAccountDomainService _userAccountDomainService;

    public UpdateUserAccountCommandHandler(IUserAccountDomainService userAccountDomainService)
    {
        _userAccountDomainService = userAccountDomainService;
    }

    public async Task<Unit> Handle(UpdateUserAccountCommand request, CancellationToken cancellationToken)
    {
        var userAccount = await _userAccountDomainService.GetByIdAsync(request.UserId,cancellationToken);

        if (userAccount == null)
        {
           throw new NotFoundException($"UserAccount with ID {request.UserId} not found.");
        }

        userAccount.UpdateUserName(request.UserName);
        userAccount.UpdateEmail(request.Email);
        await _userAccountDomainService.UpdateAsync(userAccount, cancellationToken);

        return Unit.Value;
    }

 
}
