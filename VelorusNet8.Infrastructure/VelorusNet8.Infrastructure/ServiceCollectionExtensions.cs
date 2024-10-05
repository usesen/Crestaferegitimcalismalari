using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VelorusNet8.Application.Interface.Menus;
using VelorusNet8.Application.Interface.Group;
using VelorusNet8.Application.Interface.User;
using VelorusNet8.Application.Service;
using VelorusNet8.Infrastructure.Data;
using VelorusNet8.Infrastructure.Middleware;
using VelorusNet8.Infrastructure.Repositories;
using VelorusNet8.Application.Interface.AngularDersleri;
using VelorusNet8.Infrastructure.Repositories.AngularDersleri;
using VelorusNet8.Application.Service.AngularCustomer;
using VelorusNet8.Application.Interface;
using VelorusNet8.Infrastructure.Services;




namespace VelorusNet8.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // DbContext ve diğer servisleri ekleyin
        // ConnectionString'i configuration'dan alın
        var connectionString = services.BuildServiceProvider()
                                       .GetRequiredService<IConfiguration>()
                                       .GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options =>
                                 options.UseSqlServer(connectionString));

        // Diğer servisler...

        // Redis Cache Service'i ekleyin
        services.AddSingleton<ICacheService, RedisCacheService>(provider =>
        {
            var redisConnection = configuration.GetConnectionString("RedisConnection");

            if (string.IsNullOrEmpty(redisConnection))
            {
                throw new ArgumentNullException(nameof(redisConnection), "Redis connection string cannot be null or empty.");
            }

            return new RedisCacheService(redisConnection);
        });

        services.AddScoped<IMessageBusService, RabbitMQService>(provider =>
        {
            var config = provider.GetRequiredService<IConfiguration>();
            return new RabbitMQService(config);
        });

        // ElasticSearch Service'i ekleyin
        services.AddElasticSearch(configuration["ElasticSearch:Uri"]);

        services.AddScoped<IUserAccountRepository, UserAccountRepository>();
        services.AddScoped<IUserGroupRepository, UserGroupRepository>();
        services.AddScoped<IUserGroupService, UserGroupService>();
        services.AddScoped<IMenuPermissionRepository, MenuPermissionRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();
      
        services.AddScoped<IUserAccountGroupRepository, UserAccountGroupRepository>();
        services.AddScoped<IMenuService, MenuService>();
        services.AddScoped<IMenuPermissionService, MenuPermissionService>();
        services.AddScoped<IMenuPermissionRepository, MenuPermissionRepository>();

        services.AddScoped<IAngularCustomerRepository,AngularCustomerRepository>();
        services.AddScoped<IAngularCustomerService,AngularCustomerService>();

        //services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddAuthorization(options =>
        {
            options.AddPolicy("CanViewReportsPolicy", policy =>
                policy.RequireClaim("Permission", "CanViewReports"));
        });

        return services;
    }
    public static void UseInfrastructureMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<LogMiddleware>(); // Middleware'i buradan ekliyoruz
    }
    public static IServiceCollection AddElasticSearch(this IServiceCollection services, string uri)
    {
        services.AddSingleton<ElasticSearchService>(provider =>
            new ElasticSearchService(uri));

        return services;
    }
}
