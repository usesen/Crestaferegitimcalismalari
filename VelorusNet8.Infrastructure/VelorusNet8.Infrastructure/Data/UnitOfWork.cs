using VelorusNet8.Application.Interface;
using VelorusNet8.Application.Interface.Identity;

namespace VelorusNet8.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public IRoleRepository Roles => throw new NotImplementedException();

    public Task<int> CompleteAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}