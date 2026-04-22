using Application.Abstractions.Identity;
using Application.Dtos.Identity;
using Application.Dtos.Results;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity.Services;

public class IdentityAccountService(UserManager<AppUser> userManager) : IAccountService
{
    public Task<AccountResult> DeleteUserAccountAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<AccountResult> GetUserAccountAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<AccountResult> UpdateUserAccountDetailsAsync(UpdateAccountDetails details)
    {
        throw new NotImplementedException();
    }
}