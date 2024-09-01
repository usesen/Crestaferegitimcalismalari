﻿using FluentValidation;
using MediatR;
using VelorusNet8.Application.Dtos.Identity.UserRole;
using VelorusNet8.Application.Interface.Service;
using VelorusNet8.Infrastructure.Interface;

namespace VelorusNet8.Application.Commands.Identity.UserRoleRepository;

public class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, int>
{
    private readonly IUserRoleService _userRoleService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateUserRoleCommand> _validator;

    public CreateUserRoleCommandHandler(
        IUserRoleService userRoleService,
        IUnitOfWork unitOfWork,
        IValidator<CreateUserRoleCommand> validator)
    {
        _userRoleService = userRoleService;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<int> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        // Validation işlemi
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var createUserRoleDto = new CreateUserRoleDTO
        {
            UserId = request.UserId,
            RoleId = request.RoleId
        };

        // UserRoleService kullanarak yeni bir UserRole oluştur
        var userRoleId = await _userRoleService.CreateUserRoleAsync(createUserRoleDto, cancellationToken);

        // UnitOfWork ile transaction işlemi
        await _unitOfWork.CompleteAsync(cancellationToken);

        return userRoleId;
    }
}