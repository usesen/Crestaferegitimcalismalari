using System.ComponentModel.DataAnnotations;
using VelorusNet8.Domain.Entities.Aggregates.Groups;
using VelorusNet8.Domain.Entities.Aggregates.Identity;
using VelorusNet8.Domain.Entities.Aggregates.Menus;
using VelorusNet8.Domain.Entities.Common;

namespace VelorusNet8.Domain.Entities.Aggregates.Users;

public class UserAccount : EntityBase
{
    [Key] // Bu özelliği birincil anahtar olarak belirtir
    public int UserId { get; set; }
    public string UserName { get;  set; } // Kullanıcı ismi
    public string Email { get;  set; } // kullanıcı mail
    public string PasswordHash { get;  set; }  // Şifreyi hash olarak tutmak daha güvenli
    public bool IsActive { get; set; } = true; // aktif pasif durumu akstif ise true pasif ise false
  
    // UserBranches özelliği: Bir kullanıcı birden fazla şubeye atanabilir
    public List<UserBranch> UserBranches { get; private set; } = new List<UserBranch>();
    // User ile UserGroup arasındaki ilişki (Bir kullanıcı birçok UserGroup'a sahip olabilir)
    public ICollection<UserAccountGroup> UserAccountGroups { get; set; }

    // User ile MenuPermissions arasındaki ilişki (Bir kullanıcı birçok MenuPermission'a sahip olabilir)
    public ICollection<MenuPermission> MenuPermissions { get; set; }
   

    public UserAccount() : base() // Varsayılan yapıcı
    {
    }

    public UserAccount(int userId, string username, string email, string passwordHash , bool isActive ) : base()  // UserId'yi EntityBase constructor'ına geçiyoruz
    {
        UserId = userId;
        UserName = username ?? throw new ArgumentNullException(nameof(username));
        Email = email ?? throw new ArgumentNullException(nameof(email));
        PasswordHash = passwordHash ?? throw new ArgumentNullException(nameof(passwordHash));
        IsActive = isActive;
    }

 
    public void UpdatePassword(string newPasswordHash)
    {
        PasswordHash = newPasswordHash ?? throw new ArgumentNullException(nameof(newPasswordHash));
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        var other = (UserAccount)obj;

        return 
               UserName == other.UserName &&
               Email == other.Email &&
               PasswordHash == other.PasswordHash &&
               IsActive == other.IsActive;
    }
    public void Deactivate()
    {
        IsActive = false;
    }

    public void Reactivate()
    {
        IsActive = true;
    }

    public void UpdateUserName(string newUserName)
    {
        UserName = newUserName ?? throw new ArgumentNullException(nameof(newUserName));
    }

    public void UpdateEmail(string newEmail)
    {
        Email = newEmail ?? throw new ArgumentNullException(nameof(newEmail));
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(UserId,UserName, Email, PasswordHash,IsActive );
    }
}