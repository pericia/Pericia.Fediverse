using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Pericia.ActivityPub.AspNetCoreExtensions;

public static class ActivityPubRoutesExtensions
{
    public static IEndpointRouteBuilder MapActivityPub(this IEndpointRouteBuilder app)
    {
        MapActors(app);

        return app;
    }

    private static void MapActors(this IEndpointRouteBuilder app)
    {
        app.MapControllerRoute(
            name: "ActivityPub_Actors",
            pattern: "actor/{actorId}",
            defaults: new { controller = "ActivityPub", action = "Actor" }
        );

        app.MapControllerRoute(
            name: "ActivityPub_WebFinger",
            pattern: "/.well-known/webfinger",
            defaults: new { controller="ActivityPub", action="WebFinger" });
    }
}