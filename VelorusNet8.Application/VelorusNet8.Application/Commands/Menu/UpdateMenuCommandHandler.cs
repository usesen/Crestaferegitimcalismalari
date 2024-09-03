using AutoMapper;
using FluentValidation;
using MediatR;
using VelorusNet8.Application.Exception;
using VelorusNet8.Application.Interface.Group;

namespace VelorusNet8.Application.Commands.Menu;

public class UpdateMenuCommandHandler : IRequestHandler<UpdateMenuCommand, Unit>
{
    private readonly IMenuRepository _menuRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateMenuCommand> _validator;

    public UpdateMenuCommandHandler(IMenuRepository menuRepository, IMapper mapper, IValidator<UpdateMenuCommand> validator)
    {
        _menuRepository = menuRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<Unit> Handle(UpdateMenuCommand request, CancellationToken cancellationToken)
    {   // Doğrulama işlemi
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new FluentValidation.ValidationException(validationResult.Errors);
        }

        var existingMenu = await _menuRepository.GetByIdAsync(request.MenuId, cancellationToken);

        if (existingMenu == null)
        {
            throw new NotFoundException(nameof(Menu) + " " + request.MenuId);
        }

        _mapper.Map(request, existingMenu);

        await _menuRepository.UpdateAsync(existingMenu, cancellationToken);
        return Unit.Value;
    }

    
}
