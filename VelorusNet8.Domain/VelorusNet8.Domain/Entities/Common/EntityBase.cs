using VelorusNet8.Domain.Entities.Aggregates.Users;

namespace VelorusNet8.Domain.Entities.Common;

public abstract class EntityBase
{
    public int UserId { get; private set; } // Aktif Kullanıcı Id
    public DateTime CreatedDate { get; private set; }  // Oluşturulma Tarihi
    public DateTime? UpdatedDate { get; private set; }  // Son Güncellenme Tarihi

    protected EntityBase(int userId)
    {
        CreatedDate = DateTime.Now;
        UserId = userId;
    }

    public void UpdateEntity()
    {
        UpdatedDate = DateTime.Now;
    }
}