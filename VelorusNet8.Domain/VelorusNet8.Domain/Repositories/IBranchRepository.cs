using VelorusNet8.Domain.Entities.Aggregates.Branchs;

namespace VelorusNet8.Domain.Repositories;

public interface IBranchRepository : IBaseRepository<Branch>
{
    Task CreateAsync(Branch entity, CancellationToken cancellationToken);
    Task<Branch> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<Branch>> GetAllAsync(CancellationToken cancellationToken);
    Task UpdateAsync(Branch entity, CancellationToken cancellationToken);
    Task DeleteAsync(Branch entity, CancellationToken cancellationToken);
    Task<Branch> GetBranchNameAsync(string username, CancellationToken cancellationToken);
}
