using AutoMapper;
using FluentValidation;
using MediatR;
using VelorusNet8.Application.Interface.Group;
using VelorusNet8.Domain.Entities.Aggregates.Menus;

namespace VelorusNet8.Application.Commands.Menu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, int>
{
    private readonly IMenuRepository _menuRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateMenuCommand> _validator;

    public CreateMenuCommandHandler(IMenuRepository menuRepository, IMapper mapper, IValidator<CreateMenuCommand> validator)
    {
        _menuRepository = menuRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<int> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        // Doğrulama işlemi
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        var menu = _mapper.Map<VelorusNet8.Domain.Entities.Aggregates.Menus.Menu>(request);
        await _menuRepository.AddAsync(menu, cancellationToken);
        return menu.MenuId;
    }
}
