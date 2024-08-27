namespace VelorusNet8.Application.Dto.User;

public class CreateUserAccountDto
{
    public int UserId { get; set; } 
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public bool IsActive { get; set; }
}