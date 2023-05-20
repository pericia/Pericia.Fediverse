﻿using System.Text.Json.Serialization;

namespace Pericia.ActivityPub.Model;

public class Activity
{
    [JsonPropertyName("@context")]
    public string[] Context => new[]
    {
        "https://www.w3.org/ns/activitystreams"
    };

    [JsonPropertyName("id")]
    public required string Id { get; set; }
    
    [JsonPropertyName("type")]
    public string Type => "Note";

    [JsonPropertyName("actor")]
    public required string Actor { get; set; }

    [JsonPropertyName("content")]
    public required string Content { get; set; }

    [JsonPropertyName("url")]
    public required string Url { get; set; }
    
    [JsonPropertyName("published")]
    public required DateTime Published { get; set; }
}