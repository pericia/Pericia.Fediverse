using System.Text.Json.Serialization;

namespace Pericia.ActivityStream;

public class Activity : ActivityStreamObject
{
    public override string? Type { get; init; }

    [JsonPropertyName("actor")]
    public Uri? ActorId { get; init; }

    [JsonPropertyName("object")]
    public ActivityStreamObject? Object { get; init; }
}