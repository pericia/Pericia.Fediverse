using Pericia.ActivityStream;

namespace Pericia.ActivityPub;

public interface IActivityPubProvider
{
    Actor? GetActor(string actorId);

    ActivityStreamObject? GetObject(string actorId, string objectId);
}