using VelorusNet8.Domain.Entities.Aggregates.Users;
using VelorusNet8.Domain.Entities.Common;

namespace VelorusNet8.Domain.Entities.Aggregates.Groups;

public class UserAccountGroup :EntityBase
{
  
        public int UserAccountId { get; set; }  // UserAccount ile ilişki
        public UserAccount UserAccount { get; set; }

        public int GroupId { get; set; }  // Group ile ilişki
        public UserGroup UserGroup { get; set; }

        public DateTime AssignedDate { get; set; }  // Kullanıcının gruba atandığı tarih

        public UserAccountGroup()
        {
        }
    
}
