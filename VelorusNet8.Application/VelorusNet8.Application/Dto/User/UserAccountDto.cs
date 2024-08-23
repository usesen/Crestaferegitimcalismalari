namespace VelorusNet8.Application.Dto.User;

public class UserAccountDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public bool IsActive { get; set; }
    // 4 parametreli bir yapıcı metot ekliyoruz
    public UserAccountDto(int id, string userName, string passwordHash, bool isActive, string email)
    {
        Id = id;
        UserName = userName;
        PasswordHash = passwordHash;
        IsActive = isActive;
        Email = email;
    }
}
