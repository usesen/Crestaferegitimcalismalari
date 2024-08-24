using VelorusNet8.Domain.Entities.Aggregates.Branchs;

namespace VelorusNet8.Domain.Services.Branchs;

public  class BranchDomainService
{
    private readonly List<BranchEntity> _branches = new List<BranchEntity>();

    public async Task<BranchEntity> GetByIdAsync(string branchCode, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_branches.FirstOrDefault(b => b.BranchCode == branchCode));
    }

    public async Task<IEnumerable<BranchEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await Task.FromResult(_branches.AsEnumerable());
    }

    public async Task CreateAsync(BranchEntity branch, CancellationToken cancellationToken)
    {
        if (_branches.Any(b => b.BranchCode == branch.BranchCode))
        {
            throw new InvalidOperationException("Branch already exists.");
        }

        _branches.Add(branch);
        await Task.CompletedTask;
    }

    public async Task UpdateAsync(BranchEntity branch, CancellationToken cancellationToken)
    {
        var existingBranch = _branches.FirstOrDefault(b => b.BranchCode == branch.BranchCode);

        if (existingBranch == null)
        {
            throw new KeyNotFoundException("Branch not found.");
        }

        // Update properties
        existingBranch.BranchName = branch.BranchName;
        existingBranch.Address = branch.Address;
        existingBranch.Phone = branch.Phone;
        existingBranch.Fax = branch.Fax;
        existingBranch.Email = branch.Email;
        existingBranch.CommissionRate = branch.CommissionRate;
        existingBranch.CommissionAmount = branch.CommissionAmount;
        existingBranch.DefaultShrinkageRate = branch.DefaultShrinkageRate;
        existingBranch.IsHeadOffice = branch.IsHeadOffice;
        existingBranch.IsSalesEnabled = branch.IsSalesEnabled;
        existingBranch.IsAutomationIntegrationEnabled = branch.IsAutomationIntegrationEnabled;

        await Task.CompletedTask;
    }

    public async Task DeleteAsync(string branchCode, CancellationToken cancellationToken)
    {
        var branch = _branches.FirstOrDefault(b => b.BranchCode == branchCode);

        if (branch == null)
        {
            throw new KeyNotFoundException("Branch not found.");
        }

        _branches.Remove(branch);
        await Task.CompletedTask;
    }

    public async Task<BranchEntity> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_branches.FirstOrDefault(b => b.Email == email));
    }
}
