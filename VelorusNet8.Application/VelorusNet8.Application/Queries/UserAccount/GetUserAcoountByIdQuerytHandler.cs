using AutoMapper;
using MediatR;
using VelorusNet8.Application.Dto.User;
using VelorusNet8.Application.Exception;
using VelorusNet8.Domain.Repositories;

namespace VelorusNet8.Application.Queries.UserAccount;

public class GetUserAcoountByIdQuerytHandler : IRequestHandler<GetUserAcountByIdQuery, UserAccountDto>
{
    private readonly IUserAccountRepository _userAccountRepository;
    private readonly IMapper _mapper;

    public GetUserAcoountByIdQuerytHandler(IUserAccountRepository userAccountRepository, IMapper mapper)
    {
        _userAccountRepository = userAccountRepository;
        _mapper = mapper;
    }

    public async Task<UserAccountDto> Handle(GetUserAcountByIdQuery request, CancellationToken cancellationToken)
    {
        var userAccount = await _userAccountRepository.GetByIdAsync(request.userId, cancellationToken);
        if (userAccount == null)
        {
            throw new NotFoundException($"UserAccount with ID {request.userId} not found.");
        }
        // UserAccount domain nesnesini UserAccountDto'ya dönüştürüyoruz.
        return _mapper.Map<UserAccountDto>(userAccount);
    }

}
