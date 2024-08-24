using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VelorusNet8.Application.Behaviors;
using VelorusNet8.Application.Commands.UserAccountDto;


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

        // services.AddScoped<IOtherService, OtherService>();

        return services;
    }
}