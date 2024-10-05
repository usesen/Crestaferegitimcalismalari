using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using VelorusNet8.Domain.Entities.Logs;
using VelorusNet8.Infrastructure.Services;

namespace VelorusNet8.Infrastructure.Middleware;

public class LogMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LogMiddleware> _logger;
    private readonly ElasticSearchService _elasticSearchService;

    public LogMiddleware(RequestDelegate next, ILogger<LogMiddleware> logger, ElasticSearchService elasticSearchService)
    {
        _next = next;
        _logger = logger;
        _elasticSearchService = elasticSearchService;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();
        var logEntry = new LogEntry
        {
            Message = $"Handling request: {context.Request.Method} {context.Request.Path}",
            Timestamp = DateTime.UtcNow,
            LogLevel = "Information",
            Source = "LogMiddleware"
        };
        // Log the incoming request
        _logger.LogInformation(logEntry.Message);
        await _elasticSearchService.IndexLogAsync(logEntry); // Elasticsearch'e gönder

        // Log the incoming request
        _logger.LogInformation("Handling request: {Method} {Url}", context.Request.Method, context.Request.Path);

        await _next(context); // Call the next middleware

        stopwatch.Stop();
        logEntry = new LogEntry
        {
            Message = $"Finished handling request. Status Code: {context.Response.StatusCode}. Elapsed Time: {stopwatch.ElapsedMilliseconds}ms",
            Timestamp = DateTime.UtcNow,
            LogLevel = "Information",
            Source = "LogMiddleware"
        };

        // Log the outgoing response
        _logger.LogInformation("Finished handling request. Status Code: {StatusCode}. Elapsed Time: {ElapsedMilliseconds}ms",
            context.Response.StatusCode, stopwatch.ElapsedMilliseconds);
        // Log the outgoing response
        _logger.LogInformation(logEntry.Message);
        await _elasticSearchService.IndexLogAsync(logEntry); // Elasticsearch'e gönder
    }
}
