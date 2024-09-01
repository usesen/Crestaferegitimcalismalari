using MediatR;

namespace VelorusNet8.Application.Commands.Identity.UserRoleRepository;

public class CreateUserRoleCommand : IRequest<int>
{
    public int UserId { get; set; }
    public int RoleId { get; set; }
}