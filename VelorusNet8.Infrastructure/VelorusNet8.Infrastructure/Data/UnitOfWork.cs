using VelorusNet8.Application.Interface;


namespace VelorusNet8.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
 

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> CompleteAsync(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}