using VelorusNet8.Domain.Entities.Logs;
using VelorusNet8.Infrastructure.Data;
using VelorusNet8.Infrastructure.Models;
using VelorusNet8.Infrastructure.Services;

public class RequestResponseLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ElasticSearchService _elasticSearchService;

    public RequestResponseLoggingMiddleware(RequestDelegate next, ElasticSearchService elasticSearchService)
    {
        _next = next;
        _elasticSearchService = elasticSearchService; // Elasticsearch servisini ekliyoruz
    }

    public async Task Invoke(HttpContext context)
    {
        var dbContext = context.RequestServices.GetRequiredService<AppDbContext>();

        var request = await FormatRequest(context.Request);

        var originalBodyStream = context.Response.Body;

        using (var responseBody = new MemoryStream())
        {
            context.Response.Body = responseBody;

            await _next(context);

            var response = await FormatResponse(context.Response);
            var status = context.Response.StatusCode.ToString();

            var log = new Log
            {
                Timestamp = DateTime.Now,
                Request = request,
                Response = response,
                Status = status
            };

            // Veritabanına kaydet
            dbContext.Logs.Add(log);
            await dbContext.SaveChangesAsync();

            // Elasticsearch'e log gönder
            try
            {
                var logEntry = new LogEntry
                {
                    Message = $"Request: {request}, Response: {response}, Status: {status}",
                    Timestamp = DateTime.UtcNow,
                    LogLevel = "Information",
                    Source = "RequestResponseLoggingMiddleware"
                };
                await _elasticSearchService.IndexLogAsync(logEntry);  // Elasticsearch'e gönderiyoruz
            }
            catch (Exception ex)
            {
                // Elasticsearch'e log gönderim hatalarını yakalayıp loglayın
                Console.WriteLine($"Elasticsearch'e log gönderimi başarısız: {ex.Message}");
            }

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
