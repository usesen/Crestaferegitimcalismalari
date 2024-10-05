using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using VelorusNet8.Application;
using VelorusNet8.Infrastructure;
using VelorusNet8.Infrastructure.Data;
using VelorusNet8.WebApi.Middlewares;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using VelorusNet8.Application.DTOs.User;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using VelorusNet8.Infrastructure.Initialization;
using VelorusNet8.Domain.Entities.Aggregates.Identity;
using VelorusNet8.Application.Interface;
using VelorusNet8.Infrastructure.Services;


// JWT ClaimType ayarý
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap["unique_name"] = ClaimTypes.Name;
var builder = WebApplication.CreateBuilder(args);

// AuthService'i Dependency Injection konteynerine ekleyin
builder.Services.AddScoped<AuthService>();
 

// Swagger Servis Tanýmlamasý (Bir kez olmalý)
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
 
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                 Scheme = "oauth2",
                Name = "Authorization",
                In = ParameterLocation.Header
            },
            new List<string>() // Boþ bir liste kullanabilirsiniz
        }
    });
});

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
});


// CORS politikasýný tanýmla
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder
            .WithOrigins("http://localhost:7254", "https://localhost:5058/")  // Swagger veya Angular uygulamanýn adresini ekleyin
            .AllowAnyOrigin()    // Herhangi bir origin'e izin ver
            .AllowAnyMethod()    // Herhangi bir HTTP metoduna izin ver (GET, POST, PUT, DELETE vs.)
            .AllowAnyHeader();   // Herhangi bir baþlýða izin ver
    });
});

// Yapýlandýrma dosyalarýný ekleme
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                     .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
                     .AddEnvironmentVariables();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// MediatR'ý ekleyin
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// AutoMapper ve diðer servisler
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();


builder.Services.AddHttpContextAccessor();
 
// DbContext'i ekleyin
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

//JWT Authentication yapýlandýrmasýný Swagger'ýn dýþýna alýn
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
 var app = builder.Build();
//Rolleri ve admin kullanýcýyý uygulama baþlangýcýnda ekleyin
// Database ve kullanýcý iþlemleri için scope oluþtur
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    // ApplicationDbInitializer'ý kullanarak seed iþlemini gerçekleþtir
    var dbInitializer = new ApplicationDbInitializer();
    await dbInitializer.SeedUsersAndRolesAsync(services);  // SeedUsersAndRolesAsync metodunu çaðýr
}

//Geliþtirme aþamasýnda hata sayfasý
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "text/html";

        await context.Response.WriteAsync("<h1>Oops! Something went wrong.</h1>");
        
        // Buraya loglama ekleyebilirsiniz.
    });
});


////Rolleri ve admin kullanýcýyý uygulama baþlangýcýnda ekleyin
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    await ApplicationDbInitializer.SeedUsersAndRolesAsync(services);
//}

// Middleware eklemeleri
app.UseCors("AllowAll");

// Swagger Middleware (Sadece bir kez eklenmeli)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty; // Swagger UI'yi kök dizinde gösterir
});
app.UseMiddleware<RequestResponseLoggingMiddleware>();
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication(); // Authentication önce
app.UseAuthorization();  // Sonra Authorization

// Controller mapping
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
