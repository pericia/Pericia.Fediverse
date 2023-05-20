using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Pericia.ActivityPub.Apis;

namespace Pericia.ActivityPub.AspNetCoreExtensions;

public static class ActivityPubExtensions
{
    public static IServiceCollection AddActivityPub<TActivityPubProvider>(this IServiceCollection services)
        where TActivityPubProvider : class, IActivityPubProvider
    {
        services.AddTransient<IActivityPubProvider, TActivityPubProvider>();
        services.AddTransient<ActivityPubService>();

        services.AddScoped<WebFingerApi>();

        return services;
    }

    public static IEndpointRouteBuilder UseActivityPub(this IEndpointRouteBuilder app)
    {
        app.MapGet("/.well-known/webfinger", (WebFingerApi api) => api.HandleRequest());

        return app;
    }
}