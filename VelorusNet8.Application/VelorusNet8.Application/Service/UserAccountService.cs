using AutoMapper;
using MediatR;
using VelorusNet8.Application.Commands.UserAccountDto;
using VelorusNet8.Application.Dto.User;
using VelorusNet8.Application.Exception;
using VelorusNet8.Application.Interface;
using VelorusNet8.Domain.Entities.Aggregates.Users;
using VelorusNet8.Domain.Services.UserAccountService;

namespace VelorusNet8.Application.Service;

public class UserAccounService : IUserAccountApplicationService
{
    private readonly IUserAccountDomainService _userAccountDomainService;
    private readonly IMapper _mapper;
    private readonly UserAccountCommandValidator _validator;
    private readonly IMediator _mediator;

    public UserAccounService(IUserAccountDomainService userAccountDomainService, IMapper mapper, UserAccountCommandValidator validator, IMediator mediator)
    {
        _userAccountDomainService = userAccountDomainService;
        _mapper = mapper;
        _validator = validator;
        _mediator = mediator;
    }

    public async Task CreateUserAsync(CreateUserDto createUserDto, CancellationToken cancellationToken)
    {
        var command = new CreateUserAccountCommand(createUserDto.UserName, createUserDto.Email, createUserDto.PasswordHash,createUserDto.IsActive);
        await _mediator.Send(command, cancellationToken);
 
    }

    public async Task DeactivateUserAsync(int id, CancellationToken cancellationToken)
    {
        // Kullanıcıyı ID ile getir
        var userAccount = await _userAccountDomainService.GetByIdAsync(id, cancellationToken);

        // Kullanıcıyı pasifleştir
        userAccount.Deactivate();

        // Güncellenmiş kullanıcıyı kaydet
        await _userAccountDomainService.UpdateAsync(userAccount, cancellationToken);
    }

    public async Task<IEnumerable<UserAccountDto>> GetAllUsersAsync(CancellationToken cancellationToken)
    {
        // Kullanıcıları domain servisi ile getir
        var userAccounts = await _userAccountDomainService.GetAllAsync(cancellationToken);

        // Entity'leri DTO'lara dönüştür
        return _mapper.Map<IEnumerable<UserAccountDto>>(userAccounts);
    }

    public async Task<UserAccountDto> GetUserByIdAsync(int id, CancellationToken cancellationToken)
    {
        // Kullanıcıyı ID ile getir
        var userAccount = await _userAccountDomainService.GetByIdAsync(id, cancellationToken);

        // Entity'yi DTO'ya dönüştür
        return _mapper.Map<UserAccountDto>(userAccount);
    }

    public async Task ReactivateUserAsync(int id, CancellationToken cancellationToken)
    {
        // Kullanıcıyı ID ile getir
        var userAccount = await _userAccountDomainService.GetByIdAsync(id, cancellationToken);

        // Kullanıcıyı yeniden aktif hale getir
        userAccount.Reactivate();

        // Güncellenmiş kullanıcıyı kaydet
        await _userAccountDomainService.UpdateAsync(userAccount, cancellationToken);
    }

    public async Task UpdateUserAsync(int id, UpdateUserDto updateUserDto, CancellationToken cancellationToken)
    {
        // Kullanıcıyı ID ile getir
        var userAccount = await _userAccountDomainService.GetByIdAsync(id, cancellationToken);

        // DTO'daki güncellemeleri kullanıcıya uygula
        _mapper.Map(updateUserDto, userAccount);

        // Güncellenmiş kullanıcıyı kaydet
        await _userAccountDomainService.UpdateAsync(userAccount, cancellationToken);
    }

}

