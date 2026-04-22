using Infrastructure.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence.Data;

internal static class PersistenceInitializer
{
    public static async Task InitializeDatabaseAsync(IServiceProvider serviceProvider)
    {
        await using var scope = serviceProvider.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<PersistenceContext>();

        try
        {

        }
        catch { }

    }
}