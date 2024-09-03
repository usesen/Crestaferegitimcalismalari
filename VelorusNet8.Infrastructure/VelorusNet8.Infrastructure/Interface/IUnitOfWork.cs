

namespace VelorusNet8.Application.Interface;

public interface IUnitOfWork : IDisposable
{
   
    Task<int> CompleteAsync(CancellationToken cancellationToken);
}