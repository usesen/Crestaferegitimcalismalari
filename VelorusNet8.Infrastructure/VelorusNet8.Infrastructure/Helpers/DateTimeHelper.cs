namespace VelorusNet8.Infrastructure.Helpers;

public static class DateTimeHelper
{
    public static DateTime GetIstanbulTime()
    {
        var istanbulTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");
        return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, istanbulTimeZone);
    }
}