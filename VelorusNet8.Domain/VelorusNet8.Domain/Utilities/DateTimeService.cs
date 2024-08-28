namespace VelorusNet8.Domain.Utilities;

public class DateTimeService : IDateTimeService
{
    public DateTime GetCurrentTime()
    {
        var istanbulTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");
        return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, istanbulTimeZone);
    }
}