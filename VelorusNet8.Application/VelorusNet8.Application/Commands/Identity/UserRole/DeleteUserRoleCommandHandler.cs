using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;
using VelorusNet8.Application.Interface.Service;
using VelorusNet8.Infrastructure.Interface;

namespace VelorusNet8.Application.Commands.Identity.UserRole;

public class DeleteUserRoleCommandHandler : IRequestHandler<DeleteUserRoleCommand, bool>
{
        private readonly IUserRoleService _userRoleService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<DeleteUserRoleCommand> _validator;

        public DeleteUserRoleCommandHandler(
            IUserRoleService userRoleService,
            IUnitOfWork unitOfWork,
            IValidator<DeleteUserRoleCommand> validator)
        {
            _userRoleService = userRoleService;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<bool> Handle(DeleteUserRoleCommand request, CancellationToken cancellationToken)
        {
            // Validation işlemi
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new System.ComponentModel.DataAnnotations.ValidationException(validationResult.Errors.ToString());
            }

            var result = await _userRoleService.DeleteUserRoleAsync(request.Id, cancellationToken);

            // UnitOfWork ile transaction işlemi
            await _unitOfWork.CompleteAsync(cancellationToken);

            return result;
        }
}
