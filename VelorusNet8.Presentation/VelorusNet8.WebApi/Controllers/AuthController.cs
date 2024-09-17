using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using VelorusNet8.Application.DTOs.User;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using VelorusNet8.WebApi.TokenDecode;
using VelorusNet8.Domain.Entities.Aggregates.Identity;

namespace VelorusNet8.WebApi.Controllers
{

    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {

        private readonly AuthService _authService;
        private readonly UserManager<AppUser> _userManager;

        public AuthController(AuthService authService, UserManager<AppUser> userManager)
        {
            _authService = authService;
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                return Unauthorized("Invalid credentials");
            }

            // Kullanıcı geçerli, JWT Token oluştur
            var token = await _authService.GenerateToken(user);

            // RefreshToken oluştur ve kaydet
            var refreshToken = await _authService.GenerateRefreshToken();
            await _authService.SaveRefreshToken(user, refreshToken);

            // Token'ı ve refresh token'ı döndür
            return Ok(new
            {
                Token = token,
                RefreshToken = refreshToken
            });
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenRequestDto tokenRequestDto)
        {
            // Token doğrulama ve refresh işlemi
            var principal = _authService.GetPrincipalFromExpiredToken(tokenRequestDto.Token);
            var username = principal.Identity.Name; // Kullanıcı adı, token'dan çıkarılır
            var user = await _userManager.FindByNameAsync(username);

            if (user == null || user.RefreshToken != tokenRequestDto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                return Unauthorized("Invalid refresh token");
            }

            // Yeni token ve refresh token oluştur
            var newJwtToken = await _authService.GenerateToken(user);
            var newRefreshToken = await _authService.GenerateRefreshToken();
            await _authService.SaveRefreshToken(user, newRefreshToken);

            return Ok(new
            {
                Token = newJwtToken,
                RefreshToken = newRefreshToken
            });
        }

        [HttpGet("reports")]
        public IActionResult Reports()
        {
            // İstediğiniz rapor verisini buradan dönebilirsiniz
            var reportData = new { Message = "Report data goes here" };

            return Ok(reportData); // JSON formatında yanıt döner
        }

        [Authorize(Policy = "CanViewReportsPolicy")]
        [Authorize(Roles = "Admin")]
        [HttpGet("admin-only")]
        public async Task<IActionResult> AdminOnlyAction()
        {

            //var token = HttpContext.Request.Headers["Authorization"].ToString();
            var userName = User.Identity.Name; // Kullanıcının username bilgisi
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value; // Kullanıcının ID'si

            // İstersen userName veya userId ile kullanıcı bilgilerini alabilirsin
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }

            //if (string.IsNullOrEmpty(token))
            //{
            //    return Unauthorized("Token bulunamadı");
            //}
            //else
            //{
            //    //// Token'dan gelen Unix zaman damgaları
            //    //long nbf = 1726198499;
            //    //long exp = 1726284899;

            //    //// Unix zaman damgalarını DateTime'a dönüştür
            //    //DateTimeOffset nbfDateTime = DateTimeOffset.FromUnixTimeSeconds(nbf).UtcDateTime;
            //    //DateTimeOffset expDateTime = DateTimeOffset.FromUnixTimeSeconds(exp).UtcDateTime;

            //    //// Elde edilen tarih ve saatleri yazdır
            //    //Console.WriteLine("Not Before (nbf): " + nbfDateTime);
            //    //Console.WriteLine("Expiration (exp): " + expDateTime);

            //    var authHeader = Request.Headers["Authorization"].ToString();

            //    if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
            //    {
            //        return BadRequest("Token is missing or invalid");
            //    }

            //token = authHeader.Substring("Bearer ".Length).Trim();
            //var decoder = new TokenDecoder(); // Sınıfın bir örneğini oluştur
            //var userName = decoder.DecodeToken(token);
            //user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return Unauthorized("Kullanıcı bulunamadı.");
            }

            var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("Admin"))
                {
                    return Ok("Bu aksiyon sadece Admin kullanıcılar tarafından görülebilir.");
                }
                else if (roles.Contains("User"))
                {
                    return Forbid("Bu işlem için yetkiniz yok.");
                }
            //}

            // Tüm koşullara bir yanıt eklemek gerekiyor. Bu yanıt, diğer tüm olası durumlar için dönecek bir yanıt olmalı.
            return BadRequest("Bilinmeyen bir durum oluştu.");

        }

        [HttpGet("user-only")]
        public IActionResult UserOnlyAction()
        {
            return Ok("Bu aksiyon sadece normal User kullanıcılar tarafından görülebilir.");
        }

        [HttpGet("check-roles")]
        public async Task<IActionResult> CheckUserRoles()
        {
            //var claims = User.Claims.Select(claim => new { claim.Type, claim.Value }).ToArray();
            //return Json(claims);
            // Claims'ten kullanıcı adını al
            var userNameClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userNameClaim))
            {
                return BadRequest("Kullanıcı adı bulunamadı.");
            }

            // Kullanıcıyı userManager ile bul
            var user = await _userManager.FindByNameAsync(userNameClaim);

            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }

            // Kullanıcının rollerini al
            var roles = await _userManager.GetRolesAsync(user);

            if (roles == null || !roles.Any())
            {
                return Ok("Kullanıcı herhangi bir role sahip değil.");
            }

            return Ok(new { Message = "Kullanıcının rolleri", Roles = roles });
        }

        [HttpGet("check-claims")]
        public IActionResult CheckUserClaims()
        {
            if (User.HasClaim(c => c.Type == "Permission" && c.Value == "CanViewReports"))
            {
                return Ok("Kullanıcının CanViewReports izni var.");
            }

            return Ok("Kullanıcının CanViewReports izni yok.");
        }
    }
}
//curl -X POST "https://localhost:7254/api/Auth/login" -H "Content-Type: application/json" -d '{ "Username": "user@normal.com", "Password": "User1234" }'
//curl -X GET "https://localhost:7254/api/Auth/user-only" -H "Authorization: Bearer YOUR_TOKEN_HERE"
