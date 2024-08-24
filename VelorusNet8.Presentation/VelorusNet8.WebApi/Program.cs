using MediatR;
using Microsoft.OpenApi.Models;
using VelorusNet8.Application;
using VelorusNet8.Domain.Services.Branchs;
using VelorusNet8.Domain.Services.UserAccountService;
using VelorusNet8.Infrastructure;
using VelorusNet8.Infrastructure.Middleware;


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

// Application ve Infrastructure servislerinizi ekleyin
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(); // Burada `AddInfrastructureServices`'i ekleyin

// Örnek: IRepository ve IService kayýtlarý

builder.Services.AddTransient<IBranchDomainService, BranchDomainService>();
builder.Services.AddTransient<IUserAccountDomainService, UserAccountDomainService>();

// Application servislerinizi ekleyin
builder.Services.AddApplicationServices(); // Burada AddApplicationServices çaðrýlýr
builder.Services.AddInfrastructureServices(); // Infrastructure katmaný için

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
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
