
using VelorusNet8.Domain.Entities.Aggregates.Branchs;
using VelorusNet8.Domain.Repositories;
using VelorusNet8.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace VelorusNet8.Infrastructure.Repositories;

public class BranchRepository : IBranchRepository
{
    private readonly AppDbContext _context;

    public BranchRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(BranchEntity entity, CancellationToken cancellationToken)
    {
        await _context.Branches.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(BranchEntity entity, CancellationToken cancellationToken)
    {
        _context.Branches.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<BranchEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Branches.ToListAsync(cancellationToken);
    }

    public async Task<BranchEntity> GetBranchNameAsync(string name, CancellationToken cancellationToken)
    {
        return await _context.Branches
            .FirstOrDefaultAsync(b => b.BranchName == name, cancellationToken);
    }

    public async Task<BranchEntity> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Branches
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
    }

    public async Task UpdateAsync(BranchEntity entity, CancellationToken cancellationToken)
    {
        _context.Branches.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
