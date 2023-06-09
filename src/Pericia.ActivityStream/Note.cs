﻿namespace Pericia.ActivityStream;

public class Note : CoreObject
{
    public override string? Type => "Note";

    public IEnumerable<string> To => new[] { "https://www.w3.org/ns/activitystreams#Public" };
}