using AutoMapper;
using VelorusNet8.Application.Dto.Identity.Permission.PermissionDTO;
using VelorusNet8.Application.Dto.Identity.Role;
using VelorusNet8.Domain.Entities.Aggregates.Identity;
using VelorusNet8.Application.Dto.Identity.UserRole;

namespace VelorusNet8.Application.Mappings;

public class IdentityMapping : Profile
{
    public IdentityMapping()
    {
          CreateMap<Permission, PermissionDTO>();
          CreateMap<Role, RoleDTO>();
          CreateMap<RolePermission, RolePermissionDTO>();
          CreateMap<UserRole, UserRolesDTO>();   
          
    }
   
}
