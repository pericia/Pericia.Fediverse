using System.Text.Json.Serialization;

namespace Pericia.ActivityPub.Model;

public class WebFingerAccount
{
    [JsonPropertyName("subject")]
    public required string Subject { get; set; }
    
    [JsonPropertyName("links")]
    public required IEnumerable<WebFingerLink> Links { get; set; }
}

public class WebFingerLink
{
    [JsonPropertyName("rel")]
    public required string Rel { get; set; }

    [JsonPropertyName("type")]
    public required string Type { get; set; }

    [JsonPropertyName("href")]
    public required Uri Href { get; set; }
}