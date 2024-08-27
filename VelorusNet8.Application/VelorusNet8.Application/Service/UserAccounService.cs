﻿using AutoMapper;
using MediatR;
using VelorusNet8.Application.Commands.UserAccount;
using VelorusNet8.Application.Dto.User;
using VelorusNet8.Application.Interface;
using VelorusNet8.Application.Queries.UserAccount;
using VelorusNet8.Domain.Entities.Aggregates.Users;

namespace VelorusNet8.Application.Service;

public class UserAccountService : IUserAccountService
{
    private readonly IUserAccountRepository _userAccountRepository;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public UserAccountService(IUserAccountRepository userAccountRepository, IMediator mediator, IMapper mapper)
    {
        _userAccountRepository = userAccountRepository;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<UserAccountDto> CreateUserAsync(CreateUserAccountDto createUserDto, CancellationToken cancellationToken)
    {
        // CreateUserAccountCommand ile bir komut oluştur
        var command = new CreateUserAccountCommand(
            createUserDto.UserId,
            createUserDto.UserName,
            createUserDto.Email,
            createUserDto.PasswordHash,
            createUserDto.IsActive
        );
        // MediatR kullanarak komutu işleyin
        var createdUserId = await _mediator.Send(command, cancellationToken);

        var userAccountDto = _mapper.Map<UserAccountDto>(createUserDto);

        return userAccountDto;
    }
     

    public async Task<UserAccount> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _userAccountRepository.GetByIdAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<UserAccount>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _userAccountRepository.GetAllAsync(cancellationToken);
    }

    public async Task<UserAccount> UpdateAsync(UserAccount entity, CancellationToken cancellationToken)
    {
        await _userAccountRepository.UpdateAsync(entity, cancellationToken);
        return entity;
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
