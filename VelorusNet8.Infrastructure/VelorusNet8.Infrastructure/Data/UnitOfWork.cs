using VelorusNet8.Application.Interface;
using VelorusNet8.Application.Interface.Identity;

namespace VelorusNet8.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public IRoleRepository Roles { get; private set; }
    public IPermissionRepository Permissions { get; private set; }

    public UnitOfWork(AppDbContext context, IRoleRepository roleRepository, IPermissionRepository permissionRepository)
    {
        _context = context;
        Roles = roleRepository;
        Permissions = permissionRepository;
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}