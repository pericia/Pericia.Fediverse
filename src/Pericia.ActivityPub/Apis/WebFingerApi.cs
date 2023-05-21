using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Pericia.ActivityPub.Model;

namespace Pericia.ActivityPub.Apis;

public partial class WebFingerApi
{
    private readonly HttpContext context;
    private readonly IActivityPubProvider activityPubProvider;

    public WebFingerApi(IHttpContextAccessor httpContextAccessor, IActivityPubProvider activityPubProvider)
    {
        this.context = httpContextAccessor.HttpContext
                       ?? throw new NotSupportedException();
        this.activityPubProvider = activityPubProvider;
    }

    public IResult HandleRequest()
    {
        if (context == null)
        {
            throw new NotSupportedException();
        }

        if (!context.Request.QueryString.HasValue)
        {
            return Results.NotFound();
        }

        var resource = context.Request.QueryString.Value;
        var account = GetAccount(resource);

        if (account == null)
        {
            return Results.NotFound();
        }

        return Results.Ok(account);
    }


    [GeneratedRegex(@"\?resource=(acct:(.+)@(.+))")]
    private static partial Regex ResourceRegex();

    private WebFingerAccount? GetAccount(string resource)
    {
        var match = ResourceRegex().Match(resource);
        if (!match.Success)
        {
            return null;
        }

        var domain = match.Groups[3].Value;
        var requestDomain = context.Request.Host.Host;
        if (!domain.Equals(requestDomain, StringComparison.InvariantCultureIgnoreCase))
        {
            return null;
        }

        var actorId = match.Groups[2].Value;
        var actor = activityPubProvider.GetActor(actorId);
        if (actor == null || actor.Id == null)
        {
            return null;
        }

        var account = new WebFingerAccount
        {
            Subject = match.Groups[1].Value,
            Links = new[]
            {
                new WebFingerLink
                {
                    Rel = "self",
                    Type = "application/activity+json",
                    Href = actor.Id
                }
            }
        };

        return account;
    }
}