using Pericia.ActivityPub.Model;

namespace Pericia.ActivityPub;

public interface IActivityPubProvider
{
    Actor? GetActor(string actorId);

    Activity? GetActivity(string activityId);
}