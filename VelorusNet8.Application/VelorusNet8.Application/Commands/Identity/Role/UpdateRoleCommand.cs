using MediatR;

namespace VelorusNet8.Application.Commands.Identity.Role;

public class UpdateRoleCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Description { get; set; } = string.Empty;
}
