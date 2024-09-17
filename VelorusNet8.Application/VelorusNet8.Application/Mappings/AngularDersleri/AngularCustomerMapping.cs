using AutoMapper;
using VelorusNet8.Application.Commands.AngularDersleri.AngularCustomer;
using VelorusNet8.Application.DTOs.AngularDersleri;
using VelorusNet8.Domain.Entities.Aggregates.AngularDersleri;

public class AngularCustomerMapping : Profile
{
    public AngularCustomerMapping()
    {
        CreateMap<CreateAngularCustomerCommand, AngularCustomer>();
        CreateMap<AngularCustomer, CreateAngularCustomerCommand>();
        CreateMap<AngularCustomerDto, UpdateAngularCustomerCommand>();
        // UpdateAngularCustomerCommand'i AngularCustomer entity'sine mapleyin
        CreateMap<UpdateAngularCustomerCommand, AngularCustomer>();
        CreateMap<AngularCustomerDto, CreateAngularCustomerCommand>();
    }
}

