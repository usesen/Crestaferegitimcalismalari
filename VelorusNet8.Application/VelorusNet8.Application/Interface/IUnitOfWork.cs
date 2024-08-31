using VelorusNet8.Application.Interface.Identity;

namespace VelorusNet8.Infrastructure.Interface;

public interface IUnitOfWork : IDisposable
{
    IRoleRepository Roles { get; }
    IPermissionRepository Permissions { get; }
    Task<int> CompleteAsync();
}