using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VelorusNet8.Domain.Entities.Aggregates.User;

namespace VelorusNet8.Domain.Entities.Common;

public abstract class EntityBase
{
    
    public DateTime CreatedDate { get; private set; }  // Oluşturulma Tarihi
    public DateTime? UpdatedDate { get; private set; }  // Son Güncellenme Tarihi
    public UserAccount Account { get; private set; }  // Kullanıcı Hesabı

    protected EntityBase(UserAccount account)
    {
        CreatedDate = DateTime.Now;
        Account = account;
    }

    public void UpdateEntity()
    {
        UpdatedDate = DateTime.Now;
    }
}