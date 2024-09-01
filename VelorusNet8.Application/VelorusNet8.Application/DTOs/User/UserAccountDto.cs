namespace VelorusNet8.Application.Dto.User;

public class UserAccountDto
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public bool IsActive { get; set; }
    // 4 parametreli bir yapıcı metot ekliyoruz
    public UserAccountDto(int userid, string userName,string email,string passwordHash, bool isActive)
    {
        UserId = userid;
        UserName = userName;
        PasswordHash = passwordHash;
        IsActive = isActive;
        Email = email;
    }
}
