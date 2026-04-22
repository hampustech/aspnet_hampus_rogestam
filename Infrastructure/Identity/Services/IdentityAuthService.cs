using Application.Abstractions.Identity;
using Application.Dtos.Results;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity.Services;

public class IdentityAuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager) : IAuthService
{
    public Task<AuthResult> SignInUserAsync(string email, string password, bool rememberMe = false)
    {
        throw new NotImplementedException();
    }

    public Task SignOutUserAsync()
    {
        throw new NotImplementedException();
    }
}