using Infrastructure.Identity.Data;
using Infrastructure.Persistence.Data;

namespace Infrastructure.Data;

public static class InfrastructureInitializer
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        await PersistenceInitializer.InitializeDatabaseAsync(serviceProvider);

        await IdentityInitializer.InitilizeDefaultRolesAsync(serviceProvider);

        await IdentityInitializer.InitilizeDefaultAdminAccountsAsync(serviceProvider);
    }
}