namespace UserSubeEntegrasyonTest;

public class UserAccount
{
    public int ID { get; private set; }
    public string UserName { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }

    // UserBranches özelliği: Bir kullanıcı birden fazla şubeye atanabilir
    public List<UserBranch> UserBranches { get; private set; } = new List<UserBranch>();

    public UserAccount(string username, string email, string passwordHash)
    {
        UserName = username;
        Email = email;
        PasswordHash = passwordHash;
    }
    // Parametresiz constructor
    private UserAccount() { }
}
