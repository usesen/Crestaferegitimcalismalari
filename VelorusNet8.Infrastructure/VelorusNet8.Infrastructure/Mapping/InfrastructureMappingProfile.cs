using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelorusNet8.Application.DTOs.AngularDersleri;
using VelorusNet8.Domain.Entities.Aggregates.AngularDersleri;

namespace VelorusNet8.Infrastructure.Mapping;

// VelorusNet8.Infrastructure/Mappings/InfrastructureMappingProfile.cs
public class InfrastructureMappingProfile : Profile
{
    public InfrastructureMappingProfile()
    {
        CreateMap<AngularCustomer, AngularCustomerDto>()
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
            .ForMember(dest => dest.firstName, opt => opt.MapFrom(src => src.firstName))
            .ForMember(dest => dest.lastName, opt => opt.MapFrom(src => src.lastName))
            .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.email))
            .ForMember(dest => dest.company, opt => opt.MapFrom(src => src.company))
            .ForMember(dest => dest.city, opt => opt.MapFrom(src => src.city))
            .ForMember(dest => dest.country, opt => opt.MapFrom(src => src.country));
    }
}