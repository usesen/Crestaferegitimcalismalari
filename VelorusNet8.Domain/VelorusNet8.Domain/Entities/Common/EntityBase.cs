using VelorusNet8.Domain.Entities.Aggregates.Users;
using VelorusNet8.Domain.Utilities;

namespace VelorusNet8.Domain.Entities.Common;

public abstract class EntityBase
{
    private readonly IDateTimeService _dateTimeService;
    private DateTime? _lastModifiedDate;
    private DateTime? _createdDate;
    protected EntityBase(IDateTimeService dateTimeService)
    {
        _dateTimeService = dateTimeService;
        CreatedDate = _dateTimeService.GetCurrentTime();
        LastModifiedDate = _dateTimeService.GetCurrentTime();
    }

    public int Id { get; set; }
    public DateTime? CreatedDate
    {
        get => _createdDate;
        set => _createdDate = value ?? _dateTimeService.GetCurrentTime();
    }  
    public string CreatedBy { get; set; }
    public DateTime? LastModifiedDate
    {
        get => _lastModifiedDate;
        set => _lastModifiedDate = value ?? _dateTimeService.GetCurrentTime();
    }
    public string LastModifiedBy { get; set; }

    protected EntityBase() { }

    protected EntityBase(int id)
    {
        Id = id;
    }

}