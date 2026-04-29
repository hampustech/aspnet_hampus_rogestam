using Application.Abstractions.Identity;
using Application.Dtos.Identity;
using Application.Dtos.Results;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity.Services;

public class IdentityAccountService(UserManager<AppUser> userManager) : IAccountService
{
    public async Task<AccountResult> GetUserAccountAsync(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
            return AccountResult.NotFound();

        return AccountResult.Ok(new AccountDetails(
            UserId: user.Id,
            Email: user.Email,
            FirstName: user.FirstName,
            LastName: user.LastName,
            PhoneNumber: user.PhoneNumber
        ));
    }

    public async Task<AccountResult> UpdateUserAccountDetailsAsync(UpdateAccountDetails details)
    {
        var user = await userManager.FindByIdAsync(details.UserId!);
        if (user == null)
            return AccountResult.NotFound();

        user.FirstName = details.FirstName;
        user.LastName = details.LastName;
        user.PhoneNumber = details.PhoneNumber;

        var result = await userManager.UpdateAsync(user);
        if (!result.Succeeded)
            return AccountResult.Failed(result.Errors.First().Description);

        return AccountResult.Ok();
    }

    public async Task<AccountResult> DeleteUserAccountAsync(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
            return AccountResult.NotFound();

        var result = await userManager.DeleteAsync(user);
        if (!result.Succeeded)
            return AccountResult.Failed(result.Errors.First().Description);

        return AccountResult.Ok();
    }
}