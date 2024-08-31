using MediatR;

namespace VelorusNet8.Application.Commands.Identity.Permission;

public  class CreatePermissionCommand : IRequest<int> // Dönüş tipi olarak yeni oluşturulan Permission'un Id'sini dönebiliriz
{
    public string Name { get; set; }
    public string Description { get; set; }
}
