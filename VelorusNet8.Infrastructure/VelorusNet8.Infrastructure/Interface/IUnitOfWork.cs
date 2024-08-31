using VelorusNet8.Application.Interface.Identity;

namespace VelorusNet8.Application.Interface;

public interface IUnitOfWork : IDisposable
{
    IRoleRepository Roles { get; }
    Task<int> CompleteAsync(CancellationToken cancellationToken);
}