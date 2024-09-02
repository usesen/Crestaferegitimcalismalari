using VelorusNet8.Domain.Entities.Aggregates.Identity.Interfaces;

namespace VelorusNet8.Infrastructure.Interface;

public interface IUnitOfWork : IDisposable
{
    IRoleRepository Roles { get; }
    IPermissionRepository Permissions { get; }
    IRolePermissionRepository RolePermissions { get; }
    IUserRoleRepository UserRolePermissions { get; }
    Task<int> CompleteAsync(CancellationToken cancellationToken);
}