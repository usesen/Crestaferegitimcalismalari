using Microsoft.EntityFrameworkCore;
using VelorusNet8.Application.Interface.AngularDersleri;
using VelorusNet8.Domain.Entities.Aggregates.AngularDersleri;
using VelorusNet8.Infrastructure.Data;

namespace VelorusNet8.Infrastructure.Repositories.AngularDersleri;

public class AngularCustomerRepository : IAngularCustomerRepository
{
    private readonly AppDbContext _context;

    public AngularCustomerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<AngularCustomer> GetByIdAsync(int id,CancellationToken cancellationToken)
    {
        return await _context.AngularCustomers.FindAsync(id);
    }

    public async Task<IEnumerable<AngularCustomer>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.AngularCustomers.ToListAsync();
    }

    public async Task AddAsync(AngularCustomer angularCustomer,CancellationToken cancellationToken)
    {
        await _context.AngularCustomers.AddAsync(angularCustomer);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(AngularCustomer angularCustomer, CancellationToken cancellationToken)
    {
        _context.AngularCustomers.Update(angularCustomer);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(AngularCustomer angularCustomer, CancellationToken cancellationToken)
    {
        _context.AngularCustomers.Remove(angularCustomer);
        await _context.SaveChangesAsync();
    }
}
