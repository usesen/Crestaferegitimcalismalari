using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VelorusNet8.Application.Behaviors;
using VelorusNet8.Application.Commands.UserAccount;
using VelorusNet8.Application.Interface.Group;
using VelorusNet8.Application.Interface.Menus;
using VelorusNet8.Application.Interface.User;
using VelorusNet8.Application.Service;


namespace VelorusNet8.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
       
        // AutoMapper'ı konfigüre et
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        // FluentValidation'ı konfigüre et
        services.AddValidatorsFromAssemblyContaining<UserAccountCommandValidator>();
        // MediatR'ı konfigüre et
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        // ValidationBehavior'ı konfigüre et
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        // Servisleri DI konteynerine ekle

        services.AddTransient<IUserAccountService, UserAccountService>();
        services.AddTransient<IUserGroupService, UserGroupService>();
        services.AddTransient<IMenuService, MenuService>();
        services.AddTransient<IMenuPermissionService, MenuPermissionService>();
        // services.AddScoped<IOtherService, OtherService>();
    
         
        return services;
    }
}