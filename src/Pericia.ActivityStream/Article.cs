namespace Pericia.ActivityStream;

public class Article : CoreObject
{
    public override string? Type => "Article";

    public string? Content { get; set; }

    public IEnumerable<string> To => new[] { "https://www.w3.org/ns/activitystreams#Public" };
}