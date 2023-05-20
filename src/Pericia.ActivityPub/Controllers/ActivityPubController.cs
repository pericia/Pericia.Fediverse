using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;

namespace Pericia.ActivityPub.Controllers;

public class ActivityPubController : Controller
{
    private readonly IActivityPubProvider activityPubProvider;

    public ActivityPubController(IActivityPubProvider activityPubProvider)
    {
        this.activityPubProvider = activityPubProvider;
    }

    public IActionResult Actor(string actorId)
    {
        var actor = activityPubProvider.GetActor(actorId);

        if (actor == null)
        {
            return NotFound();
        }

        return Json(actor);
    }

    //TODO : check what characters are valid
    private const string resourceRegexPattern = "acct:(.+)@(.+)";
    private static Regex resourceRegex = new Regex(resourceRegexPattern, RegexOptions.Compiled);

    public IActionResult WebFinger(string resource)
    {
        var match = resourceRegex.Match(resource);
        if (!match.Success)
        {
            return NotFound();
        }

        var domain = match.Groups[2].Value;
        var requestDomain = Request.Host.Host;
        if (!domain.Equals(requestDomain, StringComparison.InvariantCultureIgnoreCase))
        {
            return NotFound();
        }

        var actorId = match.Groups[1].Value;
        var actor = activityPubProvider.GetActor(actorId);
        if (actor == null)
        {
            return NotFound();
        }

        return Json(new
        {
            subject = resource,
            links = new[]
            {
                new
                {
                    rel = "self",
                    type = "application/activity+json",
                    href = actor.Id
                }
            }
        });
    }
}