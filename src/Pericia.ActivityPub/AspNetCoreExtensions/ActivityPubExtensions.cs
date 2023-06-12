using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        services.AddScoped<ActivityPubApi>();

        return services;
    }

    public static IApplicationBuilder UseWebFinger(this IApplicationBuilder app)
    {
        app.Map("/.well-known/webfinger", builder =>
        {
            builder.Run(context =>
            {
                var api = context.RequestServices.GetRequiredService<WebFingerApi>();
                var result = api.HandleRequest();
                return result.ExecuteAsync(context);
            });
        });

        return app;
    }

    public static IApplicationBuilder UseActivityPub(this IApplicationBuilder app, Action<IEndpointRouteBuilder>? configureAdditionalEndpoints)
    {
        app.UseWebFinger();

        app.MapWhen(context => context.Request.GetTypedHeaders().Accept.Any(h => h.MediaType == "application/ld+json" || h.MediaType == "application/activity+json"), builder =>
        {
            builder.UseRouting();
            builder.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("actor/{actorId}",
                    (string actorId, ActivityPubApi api) => api.HandleActorRequest(actorId)
                );

                endpoints.MapGet("actor/{actorId}/outbox",
                    (string actorId, ActivityPubApi api) => api.HandleOutboxRequest(actorId)
                );

                endpoints.MapPost("actor/{actorId}/inbox",
                    (string actorId, ActivityPubApi api) => api.HandleInboxRequest(actorId)
                );

                endpoints.MapGet("actor/{actorId}/notes/{objectId}",
                    (string actorId, string objectId, ActivityPubApi api) => api.HandleObjectRequest(actorId, objectId)
                );

                if (configureAdditionalEndpoints != null)
                {
                    configureAdditionalEndpoints(endpoints);
                }
            });
        });

        return app;
    }
}