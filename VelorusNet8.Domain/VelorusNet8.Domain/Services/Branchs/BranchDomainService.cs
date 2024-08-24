using VelorusNet8.Domain.Entities.Aggregates.Branchs;
using VelorusNet8.Domain.Exceptions;

namespace VelorusNet8.Domain.Services.Branchs;

public class BranchDomainService : IBranchDomainService
{
    private readonly IBranchDomainService _branchDomainService;

    public async Task<BranchEntity> GetByIdAsync(int branchId, CancellationToken cancellationToken)
    {
        var branch = await _branchDomainService.GetByIdAsync(branchId, cancellationToken);
        if (branch == null)
        {
            // Kaydın bulunamadığını belirten bir özel durum fırlatın veya uygun bir değer döndürün
            throw new NotFoundException($"Branch with code {branchId} not found");
        }
        return await _branchDomainService.GetByIdAsync(branchId, cancellationToken);
    }

    public async Task<IEnumerable<BranchEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _branchDomainService.GetAllAsync(cancellationToken);
    }

    public async Task CreateAsync(BranchEntity branch, CancellationToken cancellationToken)
    {
        if (branch == null)
        {
            throw new ArgumentNullException(nameof(branch), "Branch cannot be null");
        }

        await _branchDomainService.CreateAsync(branch, cancellationToken);
    }

    public async Task UpdateAsync(BranchEntity branch, CancellationToken cancellationToken)
    {
        var branchet = await _branchDomainService.GetByIdAsync(branch.Id, cancellationToken);
        if (branch == null)
        {
            // Kaydın bulunamadığını belirten bir özel durum fırlatın veya uygun bir değer döndürün
            throw new NotFoundException($"Branch with code {branch.Id} not found");
        }


        await _branchDomainService.UpdateAsync(branch, cancellationToken);
    }

    public async Task DeleteAsync(string branchCode, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(branchCode))
        {
            throw new ArgumentException("Branch code cannot be null or empty", nameof(branchCode));
        }

        await _branchDomainService.DeleteAsync(branchCode, cancellationToken);
    }

    public async Task<BranchEntity> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("Email cannot be null or empty", nameof(email));
        }

        return await _branchDomainService.GetByEmailAsync(email, cancellationToken);
    }
}
