﻿
using FluentValidation;


namespace VelorusNet8.Application.Commands.Identity.PermissionRepository;


public class UpdatePermissionCommandValidator : AbstractValidator<UpdatePermissionCommand>
{
    public UpdatePermissionCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Permission name is required.")
            .MaximumLength(100).WithMessage("Permission name must not exceed 100 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(250).WithMessage("Description must not exceed 250 characters.");
    }
}

