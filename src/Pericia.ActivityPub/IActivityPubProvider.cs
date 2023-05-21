using Pericia.ActivityPub.Model;

namespace Pericia.ActivityPub;

public interface IActivityPubProvider
{
    Actor? GetActor(string actorId);

    ApObject? GetObject(string actorId, string objectId);
}