using VelorusNet8.Domain.Entities.Aggregates.Branchs;

namespace VelorusNet8.Domain.Services.Branchs;

public interface IBranchDomainService
{
    Task<BranchEntity> GetByIdAsync(int branchId, CancellationToken cancellationToken);
    Task<IEnumerable<BranchEntity>> GetAllAsync(CancellationToken cancellationToken);
    Task CreateAsync(BranchEntity branch, CancellationToken cancellationToken);
    Task UpdateAsync(BranchEntity branch, CancellationToken cancellationToken);
    Task DeleteAsync(string branchCode, CancellationToken cancellationToken);
    Task<BranchEntity> GetByEmailAsync(string email, CancellationToken cancellationToken);
}