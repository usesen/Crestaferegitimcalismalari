using MediatR;

namespace VelorusNet8.Application.Commands.Identity.UserRole;

public class UpdateUserRoleCommand : IRequest<bool>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }
}
