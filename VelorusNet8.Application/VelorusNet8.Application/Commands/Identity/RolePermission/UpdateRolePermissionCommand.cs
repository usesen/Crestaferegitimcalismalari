using MediatR;

namespace VelorusNet8.Application.Commands.Identity.RoleRepository;

public  class UpdateRolePermissionCommand : IRequest<int>
{
    public int RoleId { get; set; }
    public int PermissionId { get; set; }
}
