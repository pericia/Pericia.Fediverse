using System.Text.Json.Serialization;

namespace Pericia.ActivityStream;

public class Actor : CoreObject
{
    public override string? Type => "Person";
    
    [JsonPropertyName("preferredUsername")]
    public string? PreferredUsername { get; set; }
    
    [JsonPropertyName("inbox")]
    public Uri? Inbox { get; set; }

    [JsonPropertyName("outbox")]
    public Uri? Outbox { get; set; }

    [JsonPropertyName("publicKey")]
    public PublicKey? PublicKey { get; set; }
}