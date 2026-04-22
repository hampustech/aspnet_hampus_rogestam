using Application.Abstractions.Identity;
using Infrastructure.Identity.Services;
using Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Identity.Extensions;

public static class IdentityServiceCollectionExtensions
{
    public static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<AppUser, IdentityRole>(x =>
        {
            x.SignIn.RequireConfirmedAccount = false;
            x.User.RequireUniqueEmail = true;
            x.Password.RequiredLength = 10;
        })
        .AddEntityFrameworkStores<PersistenceContext>()
        .AddDefaultTokenProviders();

        services.ConfigureApplicationCookie(x =>
        {

        });

        services.AddScoped<IAuthService, IdentityAuthService>();
        services.AddScoped<IAccountService, IdentityAccountService>();

        return services;
    }
}