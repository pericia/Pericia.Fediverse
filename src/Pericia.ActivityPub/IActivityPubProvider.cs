using Pericia.ActivityStream;

namespace Pericia.ActivityPub;

public interface IActivityPubProvider
{
    Actor? GetActor(string actorId);

    CoreObject? GetObject(string actorId, string objectId);
}