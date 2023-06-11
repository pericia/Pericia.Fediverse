using System.Text.Json.Serialization;

namespace Pericia.ActivityStream;

public class Activity : CoreObject
{
    public override string? Type { get; init; }

    [JsonPropertyName("actor")]
    public Uri? ActorId { get; init; }

    [JsonPropertyName("object")]
    public CoreObject? Object { get; init; }
}