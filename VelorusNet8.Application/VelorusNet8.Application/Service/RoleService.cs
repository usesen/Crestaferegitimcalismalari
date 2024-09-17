using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using VelorusNet8.Application.DTOs.User;
using VelorusNet8.Domain.Entities.Aggregates.Identity;

namespace VelorusNet8.Application.Service;

public class RoleService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleService(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task AddUserRole(AppUser user, string role)
    {
        if (!await _roleManager.RoleExistsAsync(role))
        {
            await _roleManager.CreateAsync(new IdentityRole(role));
        }

        if (!await _userManager.IsInRoleAsync(user, role))
        {
            await _userManager.AddToRoleAsync(user, role);
        }
    }

    public async Task AddUserClaim(AppUser user, string claimType, string claimValue)
    {
        var claim = new Claim(claimType, claimValue);
        await _userManager.AddClaimAsync(user, claim);
    }

    public async Task<List<Claim>> GetUserClaims(AppUser user)
    {
        return (await _userManager.GetClaimsAsync(user)).ToList();
    }

    public async Task<List<string>> GetUserRoles(AppUser user)
    {
        return (await _userManager.GetRolesAsync(user)).ToList();
    }
}
