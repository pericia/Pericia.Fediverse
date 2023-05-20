using Microsoft.Extensions.DependencyInjection;

namespace Pericia.ActivityPub.AspNetCoreExtensions;

public static class ActivityPubServiceCollectionExtensions
{
    public static IServiceCollection AddActivityPub<TActivityPubProvider>(this IServiceCollection services)
        where TActivityPubProvider : class, IActivityPubProvider
    {
        services.AddTransient<IActivityPubProvider, TActivityPubProvider>();
        services.AddTransient<ActivityPubService>();

        return services;
    }
}