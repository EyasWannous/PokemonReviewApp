using PokemonReviewApp.Data;

namespace PokemonReviewApp.Extensions;

public static class IHostExtension
{
    public static async Task<IHost> SeedDataAsync(this IHost host)
    {
        var scopedFactory = host.Services.GetService<IServiceScopeFactory>();
        if (scopedFactory is null)
            return host;

        using var scope = scopedFactory.CreateScope();
        
        var service = scope.ServiceProvider.GetService<DbSeeder>();
        if (service is null)
            return host;
        
        await service.SeedDataContextAsync();

        return host;
    }
}
