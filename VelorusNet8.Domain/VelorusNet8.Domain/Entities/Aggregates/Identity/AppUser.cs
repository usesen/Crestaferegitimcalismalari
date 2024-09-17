using Microsoft.AspNetCore.Identity;

namespace VelorusNet8.Domain.Entities.Aggregates.Identity;

public class AppUser : IdentityUser
{
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
}