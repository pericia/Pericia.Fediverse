using System.Text.Json.Serialization;

namespace Pericia.ActivityStream;

public class PublicKey
{
    [JsonPropertyName("id")]
    public Uri? Id { get; set; }

    [JsonPropertyName("owner")]
    public Uri? Owner { get; set; }

    [JsonPropertyName("publicKeyPem")]
    public string? PublicKeyPem { get; set; }
}