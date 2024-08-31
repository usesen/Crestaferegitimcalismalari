using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelorusNet8.Domain.Entities.Aggregates.Identity;

namespace VelorusNet8.Application.Interface.Identity;

public interface IRoleRepository
{
    Task<Role> GetRoleByIdAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<Role>> GetAllRolesAsync(CancellationToken cancellationToken);
    void Add(Role role);
    void Remove(Role role);
    void Update(Role role);
}