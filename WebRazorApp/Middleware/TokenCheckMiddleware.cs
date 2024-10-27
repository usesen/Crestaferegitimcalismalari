using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebRazorApp.Middleware;

public class TokenCheckMiddleware
{
    private readonly RequestDelegate _next;

    public TokenCheckMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var path = context.Request.Path.Value?.ToLower();
        Console.WriteLine($"Current path: {path}"); // Hangi path'de olduğumuzu görelim

        // Login ve diğer public sayfaları kontrol dışı bırakalım
        // İzin verilen yolları tanımlayalım
        var allowedPaths = new[]
        {
        "/account/login",
        "/api",
        "/css",
        "/js",
        "/lib",
        "/images"
    };
        // Eğer path izin verilen yollardan birine başlamıyorsa token kontrolü yapalım
        bool isPublicPath = allowedPaths.Any(p => path.StartsWith(p));
        Console.WriteLine($"Is public path: {isPublicPath}"); // Debug için

        if (!isPublicPath)
        {
            string token = context.Request.Cookies["authTokenRazor"];
            Console.WriteLine($"Token from cookie: {token}"); // Debug için

            if (string.IsNullOrEmpty(token))
            {
                Console.WriteLine("No token found, redirecting to login");
                context.Response.Redirect("/Account/Login");
                return;
            }
        }

        await _next(context);
    }
}

public static class TokenCheckMiddlewareExtensions
{
    public static IApplicationBuilder UseTokenCheck(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<TokenCheckMiddleware>();
    }
}