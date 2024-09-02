using AutoMapper;
using VelorusNet8.Application.Dto.Identity.Permission.PermissionDTO;
using VelorusNet8.Application.Dto.Identity.RolePermission;
using VelorusNet8.Application.Dtos.Identity.RolePermission;
using VelorusNet8.Application.Dtos.Identity.UserRole;
using VelorusNet8.Application.DTOs.Identity;
using VelorusNet8.Application.DTOs.Identity.Permission;
using VelorusNet8.Application.DTOs.Identity.Role;
using VelorusNet8.Application.DTOs.Identity.UserRole;
using VelorusNet8.Domain.Entities.Aggregates.Identity;


namespace VelorusNet8.Application.Mappings;

public class IdentityMapping : Profile
{
    public IdentityMapping()
    {
        CreateMap<Permission, PermissionDTO>();
        CreateMap<Role, RoleDTO>();
        CreateMap<RolePermission, RolePermissionDTO>();
        CreateMap<UserRole, UserRoleDTO>();
        CreateMap<Permission, PermissionDTO>();
        CreateMap<CreatePermissionDTO, Permission>();
        CreateMap<UpdatePermissionDTO, Permission>();
        CreateMap<RolePermission, RolePermissionDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Permission.Name))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => new List<RoleDTO>
                {
                    new RoleDTO { Id = src.Role.Id, Name = src.Role.Name }
                }));

        CreateMap<CreateRolePermissionDTO, RolePermission>();
        CreateMap<UpdateRolePermissionDTO, RolePermission>();
        CreateMap<UserRole, UserRoleDTO>();
        CreateMap<CreateUserRoleDTO, UserRole>();
        CreateMap<UpdateUserRoleDTO, UserRole>();

    }
   
}
