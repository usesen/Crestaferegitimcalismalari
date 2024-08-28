using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using VelorusNet8.Application;
using VelorusNet8.Infrastructure;
using VelorusNet8.Infrastructure.Data;
using VelorusNet8.Infrastructure.Middleware;
using VelorusNet8.WebApi.Middlewares;


var builder = WebApplication.CreateBuilder(args);

// Yapýlandýrma dosyalarýný ekleme
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                     .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
                     .AddEnvironmentVariables();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});
 
 
// Diðer servisleri ekleyin
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MediatR'ý ekleyin
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

//DateTime Ýstanbul UTC Service ayaða kaldýrma
//builder.Services.AddScoped<IDateTimeService, DateTimeService>();


builder.Services.AddAutoMapper(typeof(Program)); // AutoMapper profil sýnýfýnýzý içerebilir
// Application ve Infrastructure servislerinizi ekleyin
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(); // Burada `AddInfrastructureServices`'i ekleyin

// DbContext'i ekleyin
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.
builder.Services.AddHttpContextAccessor();
var app = builder.Build();

// RequestResponseLoggingMiddleware'i ekleniyor
app.UseMiddleware<RequestResponseLoggingMiddleware>();

// RequestTimeMiddleWare ekleniyor
//app.UseMiddleware<RequestTimeMiddleware>();
// Custom exception handling middleware
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // Migration'ý otomatik olarak uygulamak için
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.Migrate();
    }
}
app.UseMiddleware<LogMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty; // Swagger UI'yi kök dizinde gösterir
});


app.Run();
