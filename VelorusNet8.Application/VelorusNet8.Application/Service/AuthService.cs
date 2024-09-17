using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using VelorusNet8.Domain.Entities.Aggregates.Identity;

public class AuthService 
{
    private readonly UserManager<AppUser> _userManager;
    
    private readonly IConfiguration _configuration;

    public AuthService(UserManager<AppUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    // GenerateToken metodu burada tanımlanıyor
    public async Task<string>  GenerateToken(AppUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

        // JWT içindeki claim'leri oluştur
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim("Permission", "CanViewReports"), // Kullanıcıya claim ekleniyor

         };

        //await _userManager.AddClaimAsync(user, new Claim("Permission", "CanViewReports"));


        // Kullanıcının rollerini al
        var roles = await _userManager.GetRolesAsync(user);

        // Kullanıcının rollerini ekle
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(1),
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"],
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    // Bu metodu ekliyoruz: Süresi dolmuş bir token'dan ClaimsPrincipal çıkarmak için
    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = false, // Süresi dolmuş olabilir, bu yüzden yaşam süresi kontrol edilmez
            ValidateIssuerSigningKey = true,
            ValidIssuer = _configuration["Jwt:Issuer"],
            ValidAudience = _configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
        var jwtSecurityToken = securityToken as JwtSecurityToken;

        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Invalid token");
        }

        return principal;
    }
    public async Task<string> GenerateRefreshToken()
    {
        var randomNumber = new byte[32]; // 32 baytlık rastgele bir dize
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber); // Rastgele baytları Base64'e çevirip döndürür
        }
    }
    // Refresh Token'ı veritabanında güvenli bir şekilde saklayan metod
    public async Task SaveRefreshToken(AppUser user, string refreshToken)
    {
        // Örneğin IdentityUser nesnesinde bir RefreshToken ve RefreshTokenExpiryTime özelliği olduğunu varsayıyoruz
        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7); // Refresh token'ın süresi (örneğin 7 gün)
        await _userManager.UpdateAsync(user); // Kullanıcı bilgilerini veritabanında güncelle
        // Kullanıcıyı güncelleyin
        await _userManager.UpdateAsync(user); // Veritabanında kullanıcı bilgilerini günceller
    }
 
}
 
