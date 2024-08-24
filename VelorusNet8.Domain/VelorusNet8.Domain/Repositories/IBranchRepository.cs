using VelorusNet8.Domain.Entities.Aggregates.Branchs;

namespace VelorusNet8.Domain.Repositories;

public interface IBranchRepository : IBaseRepository<BranchEntity>
{
    Task CreateAsync(BranchEntity entity, CancellationToken cancellationToken);
    Task<BranchEntity> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<BranchEntity>> GetAllAsync(CancellationToken cancellationToken);
    Task UpdateAsync(BranchEntity entity, CancellationToken cancellationToken);
    Task DeleteAsync(BranchEntity entity, CancellationToken cancellationToken);
    Task<BranchEntity> GetBranchNameAsync(string username, CancellationToken cancellationToken);
}
