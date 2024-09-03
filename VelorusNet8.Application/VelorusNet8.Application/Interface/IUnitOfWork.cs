namespace VelorusNet8.Infrastructure.Interface;

public interface IUnitOfWork : IDisposable
{
    
    Task<int> CompleteAsync(CancellationToken cancellationToken);
}