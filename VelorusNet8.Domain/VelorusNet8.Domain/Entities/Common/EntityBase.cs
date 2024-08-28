namespace VelorusNet8.Domain.Entities.Common;

public abstract class EntityBase
{ 
    public DateTime? CreatedDate { get;set; } = DateTime.UtcNow; // Varsayılan olarak mevcut UTC zamanı atayın

    public string? CreatedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; } 

    public string? LastModifiedBy { get; set; } 

    protected EntityBase() { }
 
}