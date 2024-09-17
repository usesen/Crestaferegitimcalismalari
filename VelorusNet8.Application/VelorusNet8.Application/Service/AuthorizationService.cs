using Microsoft.AspNetCore.Identity;
using VelorusNet8.Domain.Entities.Aggregates.Identity;

namespace VelorusNet8.Application.Service;

public class AuthorizationService
{
    private readonly UserManager<AppUser> _userManager;

    public AuthorizationService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<bool> IsUserInRole(AppUser user, string role)
    {
        return await _userManager.IsInRoleAsync(user, role);
    }

    public async Task<bool> DoesUserHaveClaim(AppUser user, string claimType, string claimValue)
    {
        var claims = await _userManager.GetClaimsAsync(user);
        return claims.Any(c => c.Type == claimType && c.Value == claimValue);
    }
}
