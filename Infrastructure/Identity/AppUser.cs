using Microsoft.AspNetCore.Identity;
using System.Net.NetworkInformation;

namespace Infrastructure.Identity;

public class AppUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? ImageUrl { get; set; }


    public static AppUser Create(string email)
    {
        return new AppUser
        {
            UserName = email.Trim().ToLowerInvariant(),
            Email = email.Trim().ToLowerInvariant()
        };
    }

    public static AppUser Create(string email, string? firstName = null, string? lastName = null, string? imageUrl = null)
    {
        return new AppUser
        {
            UserName = email.Trim().ToLowerInvariant(),
            Email = email.Trim().ToLowerInvariant(),
            FirstName = firstName?.Trim(),
            LastName = lastName?.Trim()
        };
    }
}