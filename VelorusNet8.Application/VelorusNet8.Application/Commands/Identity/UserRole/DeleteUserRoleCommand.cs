using MediatR;

namespace VelorusNet8.Application.Commands.Identity.UserRole;

public class DeleteUserRoleCommand : IRequest<bool>
{
    public int Id { get; set; }
}