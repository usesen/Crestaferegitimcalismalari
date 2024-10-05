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
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        // DbContext ve diğer servisleri ekleyin
        // ConnectionString'i configuration'dan alın
        var connectionString = services.BuildServiceProvider()
                                       .GetRequiredService<IConfiguration>()
                                       .GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options =>
                                 options.UseSqlServer(connectionString));

        // Diğer servisler...


        // Redis Cache Service'i ekleyin (ICacheService uygulaması olarak)
        services.AddSingleton<ICacheService, RedisCacheService>(provider =>
        {
            var redisConnection = services.BuildServiceProvider()
                   .GetRequiredService<IConfiguration>()
                   .GetConnectionString("RedisConnection");

            return new RedisCacheService(redisConnection); // Redis bağlantı bilgisi
        });

        services.AddSingleton<ICacheService, RedisCacheService>(provider =>
        {
            var elasticSearchUri = services.BuildServiceProvider()
                   .GetRequiredService<IConfiguration>()
                   .GetConnectionString("ElasticSearch:Uri\"");

            return new RedisCacheService(elasticSearchUri); // Redis bağlantı bilgisi
        });

        services.AddElasticSearch("http://localhost:9200");

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
