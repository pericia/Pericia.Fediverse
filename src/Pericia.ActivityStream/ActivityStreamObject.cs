using System.Text.Json.Serialization;

namespace Pericia.ActivityStream;

public class ActivityStreamObject
{
    [JsonPropertyName("@context")]
    public string[] Context => new[]
    {
        "https://www.w3.org/ns/activitystreams"
    };

    [JsonPropertyName("id")]
    public Uri? Id { get; init; }

    [JsonPropertyName("type")]
    public virtual string? Type { get; init; }

    [JsonPropertyName("actor")]
    public Uri? ActorId { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("attributedTo")]
    public string? AttributedTo { get; init; }

    [JsonPropertyName("published")]
    public DateTime? Published { get; init; }
    

    [JsonPropertyName("url")]
    public Uri? Url { get; init; }
}