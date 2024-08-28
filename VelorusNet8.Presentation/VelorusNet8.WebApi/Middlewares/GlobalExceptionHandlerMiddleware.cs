using Newtonsoft.Json;

namespace VelorusNet8.WebApi.Middlewares;

public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;

        var result = JsonConvert.SerializeObject(new { error = exception.Message });
        return context.Response.WriteAsync(result);
    }
}

