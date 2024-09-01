using MediatR;

namespace VelorusNet8.Application.Commands.Identity.RolePermission;

public  class CreateRolePermissionCommand : IRequest<int>
{
    public int RoleId { get; set; }
    public int PermissionId { get; set; }
}
