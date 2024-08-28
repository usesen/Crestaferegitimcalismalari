namespace VelorusNet8.WepApi.WpDto.WpUser;

public class CreateUserAcountDtoWpa
{
    public int UserId {  get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public bool IsActive { get; set; }
}