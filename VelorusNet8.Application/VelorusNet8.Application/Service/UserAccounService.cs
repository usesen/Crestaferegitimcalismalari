using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using VelorusNet8.Application.Commands.UserAccount;
using VelorusNet8.Application.Dto.User;
using VelorusNet8.Application.Interface;
using VelorusNet8.Application.Interface.User;
using VelorusNet8.Domain.Entities.Aggregates.Users;


namespace VelorusNet8.Application.Service;

public class UserAccountService : IUserAccountService
{
    private readonly IUserAccountRepository _userAccountRepository;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ICacheService _cacheService; // Redis Cache Entegrasyonu
    private readonly IConfiguration _configuration;
    private readonly IMessageBusService _messageBusService;

    public UserAccountService(IUserAccountRepository userAccountRepository, IMediator mediator, IMapper mapper, ICacheService cacheService, IConfiguration configuration, IMessageBusService messageBusService)
    {
        _userAccountRepository = userAccountRepository;
        _mediator = mediator;
        _mapper = mapper;
        _cacheService = cacheService;
        _configuration = configuration;
        _messageBusService = messageBusService;
    }

    public async Task<int> CreateUserAsync(CreateUserAccountDto createUserDto, CancellationToken cancellationToken)
    {
        // DTO'yu Command'e dönüştürün
        var command = new CreateUserAccountCommand(
            createUserDto.UserName,
            createUserDto.Email,
            createUserDto.PasswordHash,
            createUserDto.IsActive
        );
        // MediatR kullanarak komutu işleyin
        var createdUserId = await _mediator.Send(command, cancellationToken);

        var response = await _messageBusService.PublishMessageAsync("Yeni kullanıcı kaydedildi.");
        Console.WriteLine($"RabbitMQ'dan gelen cevap: {response}");


        return createdUserId;
    }

    public async Task<int> UpdateUserAsync(UpdateUserAccountDto updateUserDto, CancellationToken cancellationToken)
    {
        // DTO'yu Command'e dönüştürün
        var command = new UpdateUserAccountCommand(
           updateUserDto.Id,            // Burada DTO yerine Command kullanıyoruz
           updateUserDto.UserName,
           updateUserDto.Email,
           updateUserDto.PasswordHash,
           updateUserDto.IsActive
        );
        // MediatR kullanarak komutu işleyin
        var updateUserId = await _mediator.Send(command, cancellationToken);

        return updateUserId;
    }

    public async Task<UserAccount> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _userAccountRepository.GetByIdAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<UserAccount>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _userAccountRepository.GetAllAsync(cancellationToken);
    }


    public async Task DeleteAsync(int userId, CancellationToken cancellationToken)
    {
        await _userAccountRepository.DeleteAsync(userId, cancellationToken);
    }

    public async Task<UserAccount> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await _userAccountRepository.GetByEmailAsync(email, cancellationToken);
    }

    public async Task<UserAccount> GetByUserNameAsync(string username, CancellationToken cancellationToken)
    {
        return await _userAccountRepository.GetByUserNameAsync(username, cancellationToken);
    }

    public async Task<UserAccount> GetUsersWithBranches(int id, CancellationToken cancellationToken)
    {
        return await _userAccountRepository.GetUsersWithBranchesAsync(id, cancellationToken);
    }

   
}
