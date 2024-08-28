using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VelorusNet8.Application.Interface;
using VelorusNet8.Domain.Utilities;
using VelorusNet8.Infrastructure.Data;
using VelorusNet8.Infrastructure.Middleware;
using VelorusNet8.Infrastructure.Repositories;


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
        services.AddTransient<IUserAccountRepository, UserAccountRepository>();
     
        return services;
    }
    public static void UseInfrastructureMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<LogMiddleware>(); // Middleware'i buradan ekliyoruz
    }
}
