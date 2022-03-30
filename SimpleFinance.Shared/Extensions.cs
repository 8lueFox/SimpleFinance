using Microsoft.Extensions.DependencyInjection;
using SimpleFinance.Shared.Services;

namespace SimpleFinance.Shared;

public static class Extensions
{
    public static IServiceCollection AddShared(this IServiceCollection services)
    {
        services.AddHostedService<AppInitializer>();

        return services;
    }
}
