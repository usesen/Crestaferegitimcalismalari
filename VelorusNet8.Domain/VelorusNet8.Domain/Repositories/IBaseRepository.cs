using VelorusNet8.Domain.Entities.Common;

namespace VelorusNet8.Domain.Repositories;

public interface IBaseRepository<T> where T : class 
{
    Task CreateAsync(T entity, CancellationToken cancellationToken);
    Task<T> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
    Task UpdateAsync(T entity, CancellationToken cancellationToken);
    Task DeleteAsync(T entity, CancellationToken cancellationToken);
}
