namespace VelorusNet8.WepApi.Dto.User;

public class UserAccountDtoWpa
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public bool IsActive { get; set; }
    // 4 parametreli bir yapıcı metot ekliyoruz
    public UserAccountDtoWpa(int userid, string userName,string email,string passwordHash, bool isActive)
    {
        UserId = userid;
        UserName = userName;
        PasswordHash = passwordHash;
        IsActive = isActive;
        Email = email;
    }
}
