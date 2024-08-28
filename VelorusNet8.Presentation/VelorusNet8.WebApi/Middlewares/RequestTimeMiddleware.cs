using VelorusNet8.Domain.Utilities;

namespace VelorusNet8.WebApi.Middlewares;

public class RequestTimeMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IDateTimeService _dateTimeService;

    public RequestTimeMiddleware(RequestDelegate next, IDateTimeService dateTimeService)
    {
        _next = next;
        _dateTimeService = dateTimeService;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Örneğin, isteğin işlendiği saati loglayabilirsiniz
        var requestTime = _dateTimeService.GetCurrentTime();
        context.Response.Headers.Add("X-Request-Time", requestTime.ToString("o"));

        // Sonraki middleware'i çağır
        await _next(context);
    }
}