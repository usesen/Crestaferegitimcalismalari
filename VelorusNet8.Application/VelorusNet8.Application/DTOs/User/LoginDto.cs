using Microsoft.AspNetCore.Identity;

namespace VelorusNet8.Application.DTOs.User;

public class LoginDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class TokenRequestDto
{
    public string Token { get; set; }          // Geçerliliğini yitirmiş JWT token
    public string RefreshToken { get; set; }   // Refresh token
}
