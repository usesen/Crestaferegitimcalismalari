using Microsoft.IdentityModel.Logging;
using System.IdentityModel.Tokens.Jwt;

namespace VelorusNet8.WebApi.TokenDecode;

public class TokenDecoder // Sınıf içine almalısınız
{
    public string DecodeToken(string token)
    {
        if (string.IsNullOrEmpty(token) || !token.Contains("."))
        {
            throw new ArgumentException("Invalid JWT token format.");
        }
        IdentityModelEventSource.ShowPII = true;

        try
        {
            var tokenParts = token.Split('.');
            if (tokenParts.Length != 3)
            {
                throw new ArgumentException("Invalid JWT token. It should have three parts.");
            }
            var header = DecodeBase64Url(tokenParts[0]);
            var payload = DecodeBase64Url(tokenParts[1]);

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var userNameClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value;
            return userNameClaim;
        }
        catch (Exception ex)
        {
            throw new Exception("Token parsing failed.", ex);
        }
    }
    public string DecodeBase64Url(string base64Url)
    {
        base64Url = base64Url.Replace('-', '+').Replace('_', '/');
        switch (base64Url.Length % 4)
        {
            case 2: base64Url += "=="; break;
            case 3: base64Url += "="; break;
        }
        var bytes = Convert.FromBase64String(base64Url);
        return System.Text.Encoding.UTF8.GetString(bytes);
    }

}