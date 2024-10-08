﻿using AutoMapper;
using FluentValidation;
using MediatR;
using VelorusNet8.Application.Interface.Menus;
using VelorusNet8.Domain.Entities.Aggregates.Menus;

namespace VelorusNet8.Application.Commands.Menu;

public class CreateMenuPermissionCommandHandler : IRequestHandler<CreateMenuPermissionCommand, Unit>
{
    private readonly IMenuPermissionRepository _menuPermissionRepository;
    private readonly IValidator<CreateMenuPermissionCommand> _validator;

    public CreateMenuPermissionCommandHandler(IMenuPermissionRepository menuPermissionRepository, IValidator<CreateMenuPermissionCommand> validator)
    {
        _menuPermissionRepository = menuPermissionRepository;
        _validator = validator;
    }

    public async Task<Unit> Handle(CreateMenuPermissionCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var menuPermission = await _menuPermissionRepository.GetByIdAsync(request.MenuId, cancellationToken);

        if (menuPermission == null)
        {
            throw new KeyNotFoundException("MenuPermission not found.");
        }

        menuPermission.MenuId = request.MenuId;
        menuPermission.UserAccountId = request.UserAccountId;
        menuPermission.GroupId = request.GroupId;
        menuPermission.CanView = request.CanView;
        menuPermission.CanEdit = request.CanEdit;
        menuPermission.CanDelete = request.CanDelete;
        menuPermission.CanExcel = request.CanExcel;
        menuPermission.CanPdf = request.CanPdf;
        menuPermission.CanWord = request.CanWord;

        await _menuPermissionRepository.UpdateAsync(menuPermission, cancellationToken);

        return Unit.Value;
    }
}