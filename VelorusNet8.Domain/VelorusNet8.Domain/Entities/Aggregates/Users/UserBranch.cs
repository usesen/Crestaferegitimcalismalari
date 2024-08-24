using VelorusNet8.Domain.Entities.Aggregates.Branchs;

namespace VelorusNet8.Domain.Entities.Aggregates.Users;

public class UserBranch
{
    public int UserId { get; private set; }
    public UserAccount UserAccount { get; private set; }

    public int BranchId { get; private set; }
    public BranchEntity Branch { get; private set; }

    // Constructor'da sadece mapped (veritabanında doğrudan eşlenen) özellikleri kullanıyoruz
    public UserBranch(int userId, int branchId)
    {
        UserId = userId;
        BranchId = branchId;
    }

    // Navigation properties için setter methodları veya property ayarları kullanılabilir
    public void SetUserAccount(UserAccount userAccount)
    {
        UserAccount = userAccount ?? throw new ArgumentNullException(nameof(userAccount));
    }

    public void SetBranch(BranchEntity branch)
    {
        Branch = branch ?? throw new ArgumentNullException(nameof(branch));
    }
}
