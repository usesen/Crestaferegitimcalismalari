using MediatR;

namespace VelorusNet8.Application.Commands.Identity.PermissionRepository;

public  class UpdatePermissionCommand :  IRequest<bool>
{
    public int Id { get; set; }  // Güncellenecek Permission'ın Id'si
    public string Name { get; set; }  // Güncellenecek Name özelliği
    public string Description { get; set; } // Güncellenecek Name özelliği
}
