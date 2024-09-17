using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using System.Security.Cryptography;
using VelorusNet8.Domain.Entities.Aggregates.Identity;

namespace VelorusNet8.Infrastructure.Initialization;
public  class ApplicationDbInitializer
{
    public async Task SeedUsersAndRolesAsync(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        // Admin rolü mevcut değilse oluştur
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        // Admin kullanıcıyı ekle
        var adminUser = await userManager.FindByEmailAsync("admin@admin.com");

        if (adminUser == null)
        {
            var user = new AppUser
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                EmailConfirmed = true,
                RefreshToken = GenerateRefreshToken(),  // Refresh token oluşturuluyor
                RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7)  // Refresh token süresi
            };
             
            var result = await userManager.CreateAsync(user, "User1234!");
            if (result.Succeeded)
            {
                // Admin rolünü kullanıcıya ekle
                await userManager.AddToRoleAsync(user, "Admin");
                // Kullanıcıya claim ekle
                await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Admin"));
                // Admin için özel claim'ler (yetkiler) ekle
                await AddClaimIfNotExists(userManager, user, "Permission", "CanViewReports");
                await AddClaimIfNotExists(userManager, user, "Permission", "CanManageUsers");
            }
        }
    }

    public async Task AddClaimIfNotExists(UserManager<AppUser> userManager, AppUser user, string claimType, string claimValue)
    {
        // Kullanıcının var olan claim'lerini al
        var existingClaims = await userManager.GetClaimsAsync(user);

        // Claim'ler içinde hem Type hem de Value'ya göre kontrol et
        var existingClaim = existingClaims.FirstOrDefault(c => c.Type == claimType && c.Value == claimValue);

        // Eğer bu claim yoksa, ekle
        if (existingClaim == null)
        {
            await userManager.AddClaimAsync(user, new Claim(claimType, claimValue));
        }
    }
    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[32]; // 32 baytlık rastgele bir dize
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber); // Rastgele baytları Base64'e çevirip döndürür
        }
    }
   
}
