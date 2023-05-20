using System.Text.Json.Serialization;

namespace Pericia.ActivityPub.Model;

public class Actor
{
    [JsonPropertyName("@context")]
    public string[] Context => new[] { "https://www.w3.org/ns/activitystreams", "https://w3id.org/security/v1" };

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("type")]
    public string Type => "Person";

    [JsonPropertyName("name")]
    public required string Name { get; set; }
    
    [JsonPropertyName("preferredUsername")]
    public required string PreferredUsername { get; set; }

    [JsonPropertyName("inbox")]
    public required string Inbox { get; set; }

    [JsonPropertyName("outbox")]
    public required string Outbox { get; set; }

    [JsonPropertyName("publicKey")]
    public required PublicKey PublicKey { get; set; }
}

public class PublicKey
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("owner")]
    public required string Owner { get; set; }

    [JsonPropertyName("publicKeyPem")]
    public required string PublicKeyPem { get; set; }
}