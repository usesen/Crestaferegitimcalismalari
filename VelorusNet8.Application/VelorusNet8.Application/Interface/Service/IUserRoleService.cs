using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelorusNet8.Domain.Entities.Aggregates.Identity;

namespace VelorusNet8.Application.Interface.Service;

public interface IUserRoleService
{
    Task<UserRole> GetByIdAsync(int id);
    Task<IEnumerable<UserRole>> GetAllAsync();
    void Add(UserRole userRole);
    void Remove(UserRole userRole);
}
