using AutoMapper;
using VelorusNet8.Application.Dto.User;
using VelorusNet8.Application.Exception;
using VelorusNet8.Application.Interface;
using VelorusNet8.Domain.Entities.Aggregates.Users;
using VelorusNet8.Domain.Repositories;

namespace VelorusNet8.Application.Service;

public class UserService : IUserAccountService
{
    private readonly IUserAccountRepository _userAccountRepository;
    private readonly IMapper _mapper;

    public UserService(IUserAccountRepository userRepository, IMapper mapper)
    {
        _userAccountRepository = userRepository;
        _mapper = mapper;
    }

    public async Task CreateUserAsync(CreateUserDto createUserDto, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<UserAccount>(createUserDto);
        await _userAccountRepository.CreateAsync(user, cancellationToken);
    }

    public async Task DeactivateUserAsync(int userId, CancellationToken cancellationToken)
    {
        var user = await _userAccountRepository.GetByIdAsync(userId, cancellationToken);
        if (user == null)
        {
            throw new NotFoundException("User not found.");
        }

        user.Deactivate();
        await _userAccountRepository.UpdateAsync(user, cancellationToken);
    }
    public async Task ReactivateUserAsync(int userId, CancellationToken cancellationToken)
    {
        var user = await _userAccountRepository.GetByIdAsync(userId, cancellationToken);
        if (user == null)
        {
            throw new NotFoundException("User not found.");
        }

        user.Reactivate();
        await _userAccountRepository.UpdateAsync(user, cancellationToken);
    }
    public async Task<IEnumerable<UserAccountDto>> GetAllUsersAsync(CancellationToken cancellationToken)
    {
        var users = await _userAccountRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<IEnumerable<UserAccountDto>>(users);
    }

    public async Task<UserAccountDto> GetUserByIdAsync(int id, CancellationToken cancellationToken)
    {
        var user = await _userAccountRepository.GetByIdAsync(id, cancellationToken);
        if (user == null)
        {
            throw new NotFoundException($"User with ID {id} not found.");
        }
        return _mapper.Map<UserAccountDto>(user);
    }

    public async Task UpdateUserAsync(int id, UpdateUserDto updateUserDto, CancellationToken cancellationToken)
    {
        var user = await _userAccountRepository.GetByIdAsync(id, cancellationToken);
        if (user == null)
        {
            throw new NotFoundException($"User with ID {id} not found.");
        }

        // Map updates
        _mapper.Map(updateUserDto, user);

        await _userAccountRepository.UpdateAsync(user, cancellationToken);
    }
}

