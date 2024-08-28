using VelorusNet8.Domain.Utilities;
using VelorusNet8.Infrastructure.Data;
using VelorusNet8.Infrastructure.Models;

namespace VelorusNet8.WebApi.Middlewares;


public class RequestResponseLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IDateTimeService _dateTimeService;
    public RequestResponseLoggingMiddleware(RequestDelegate next, IDateTimeService dateTimeService)
    {
        _next = next;
        _dateTimeService = dateTimeService;
    }


    public async Task Invoke(HttpContext context)
    {
        // HttpContext'ten scoped hizmetleri çözümleyin
        var dbContext = context.RequestServices.GetRequiredService<AppDbContext>();
      

        // Request'i yakala
        var request = await FormatRequest(context.Request);

        // Response'u yakalamak için response stream'ini tut
        var originalBodyStream = context.Response.Body;

        using (var responseBody = new MemoryStream())
        {
            context.Response.Body = responseBody;

            await _next(context);

            // Response'u yakala
            var response = await FormatResponse(context.Response);
            var status = context.Response.StatusCode.ToString();

            // Log kaydını oluştur
            var log = new Log
            {
                Timestamp = _dateTimeService.GetCurrentTime(),//DateTime.UtcNow,
                Request = request,
                Response = response,
                Status = status
            };

            // Log kaydını veritabanına ekle
            dbContext.Logs.Add(log);
            await dbContext.SaveChangesAsync();

            await responseBody.CopyToAsync(originalBodyStream);
        }
    }
    private async Task<string> FormatRequest(HttpRequest request)
    {
        request.EnableBuffering();
        var buffer = new byte[Convert.ToInt32(request.ContentLength)];
        await request.Body.ReadAsync(buffer, 0, buffer.Length);
        var bodyAsText = System.Text.Encoding.UTF8.GetString(buffer);
        request.Body.Position = 0;

        return $"{request.Method} {request.Scheme} {request.Host}{request.Path} {request.QueryString} {bodyAsText}";
    }

    private async Task<string> FormatResponse(HttpResponse response)
    {
        response.Body.Seek(0, SeekOrigin.Begin);
        var text = await new StreamReader(response.Body).ReadToEndAsync();
        response.Body.Seek(0, SeekOrigin.Begin);

        return $"{response.StatusCode}: {text}";
    }
}
