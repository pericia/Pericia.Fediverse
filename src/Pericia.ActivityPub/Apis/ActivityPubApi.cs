using Microsoft.AspNetCore.Http;

namespace Pericia.ActivityPub.Apis;

public class ActivityPubApi
{
    private readonly HttpContext context;
    private readonly IActivityPubProvider activityPubProvider;
    
    public ActivityPubApi(IHttpContextAccessor httpContextAccessor, IActivityPubProvider activityPubProvider)
    {
        this.context = httpContextAccessor.HttpContext
                       ?? throw new NotSupportedException();
        this.activityPubProvider = activityPubProvider;
    }
    
    public IResult HandleActorRequest(string actorId)
    {
        var actor = activityPubProvider.GetActor(actorId);

        if (actor == null)
        {
            return Results.NotFound();
        }

        return Results.Ok(actor);
    }

    public IResult HandleActivityRequest(string activityId)
    {
        var activity = activityPubProvider.GetActivity(activityId);
        
        if (activity == null)
        {
            return Results.NotFound();
        }

        return Results.Ok(activity);
    }
}