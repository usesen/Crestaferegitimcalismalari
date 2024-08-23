using MediatR;
using VelorusNet8.Application.Exception;
using VelorusNet8.Domain.Repositories;

namespace VelorusNet8.Application.Commands.UserAccount;

public class UpdateUserAccountCommandHandler : IRequestHandler<UpdateUserAccountCommand, Unit>
{
    private readonly IUserAccountRepository _userRepository;

    public UpdateUserAccountCommandHandler(IUserAccountRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(UpdateUserAccountCommand request, CancellationToken cancellationToken)
    {
        var userAccount = await _userRepository.GetByIdAsync(request.UserId,cancellationToken);

        if (userAccount == null)
        {
           throw new NotFoundException($"UserAccount with ID {request.UserId} not found.");
        }

        userAccount.UpdateUserName(request.UserName);
        userAccount.UpdateEmail(request.Email);
        await _userRepository.UpdateAsync(userAccount, cancellationToken);

        return Unit.Value;
    }

 
}
