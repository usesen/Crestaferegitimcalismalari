using MediatR;

namespace VelorusNet8.Application.Commands.Identity.PermissionRepository;

public  class UpdatePermissionCommand :  IRequest<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
}
