using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using VelorusNet8.Application.Commands.UserAccountDto;
using VelorusNet8.Application.Mappings;

namespace VelorusNet8.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(UserAccountMapping).Assembly);
        // Application katmanındaki servisleri ekle
 
        services.AddValidatorsFromAssemblyContaining<UserAccountCommandValidator>();

        // services.AddScoped<IOtherService, OtherService>();

        return services;
    }
}