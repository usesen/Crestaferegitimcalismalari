using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelorusNet8.Domain.Entities.Aggregates.Identity;

namespace VelorusNet8.Application.Interface.Identity;

public interface IPermissionRepository
{
    Task<Permission> GetPermissionByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<Permission>> GetAllPermissionsAsync(CancellationToken cancellationToken);
    void Add(Permission permission);
    void Remove(Permission permission);
}