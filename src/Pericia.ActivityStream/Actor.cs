using System.Text.Json.Serialization;

namespace Pericia.ActivityStream;

public class Actor : ActivityStreamObject
{
    public override string? Type => "Person";

    [JsonPropertyName("inbox")]
    public Uri? Inbox { get; set; }

    [JsonPropertyName("outbox")]
    public Uri? Outbox { get; set; }

    [JsonPropertyName("publicKey")]
    public PublicKey? PublicKey { get; set; }
}