using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace VelorusNet8.Infrastructure.Middleware;

public class LogMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LogMiddleware> _logger;

    public LogMiddleware(RequestDelegate next, ILogger<LogMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();

        // Log the incoming request
        _logger.LogInformation("Handling request: {Method} {Url}", context.Request.Method, context.Request.Path);

        await _next(context); // Call the next middleware

        stopwatch.Stop();

        // Log the outgoing response
        _logger.LogInformation("Finished handling request. Status Code: {StatusCode}. Elapsed Time: {ElapsedMilliseconds}ms",
            context.Response.StatusCode, stopwatch.ElapsedMilliseconds);
    }
}
