using Application.Abstractions.Identity;
using Application.Dtos.Results;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity.Services;

public class IdentityAuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : IAuthService
{
    public async Task<AuthResult> SignUpUserAsync(string email, string password)
    {
        var user = new AppUser
        {
            UserName = email,
            Email = email
        };

        var result = await userManager.CreateAsync(user, password);

        if (!result.Succeeded)
        {
            var error = result.Errors.First().Description;
            return AuthResult.Failed(error);
        }

        return AuthResult.Ok();
    }

    public async Task<AuthResult> SignInUserAsync(string email, string password, bool rememberMe = false)
    {
        var result = await signInManager.PasswordSignInAsync(email, password, rememberMe, lockoutOnFailure: false);

        if (!result.Succeeded)
            return AuthResult.Failed("Invalid email or password");

        return AuthResult.Ok();
    }

    public async Task SignOutUserAsync()
    {
        await signInManager.SignOutAsync();
    }
}