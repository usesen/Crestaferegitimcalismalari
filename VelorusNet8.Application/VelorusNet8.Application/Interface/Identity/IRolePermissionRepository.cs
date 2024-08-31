﻿using VelorusNet8.Domain.Entities.Aggregates.Identity;

namespace VelorusNet8.Application.Interface.Identity;

public interface IRolePermissionRepository
{
    Task<RolePermission> GetByIdAsync(int id);
    Task<IEnumerable<RolePermission>> GetAllAsync();
    void Add(RolePermission rolePermission);
    void Remove(RolePermission rolePermission);
}
