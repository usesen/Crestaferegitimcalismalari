﻿using Microsoft.Extensions.DependencyInjection;
using VelorusNet8.Application.Interface;
using VelorusNet8.Application.Mappings;
using VelorusNet8.Application.Service;

namespace VelorusNet8.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(UserAccountMapping).Assembly);
        // Application katmanındaki servisleri ekle
        services.AddScoped<IUserAccountService, UserService>();
        
        // Diğer servisler
        // services.AddScoped<IOtherService, OtherService>();

        return services;
    }
}