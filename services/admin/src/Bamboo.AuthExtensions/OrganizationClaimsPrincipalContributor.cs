using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OpenIddict.Abstractions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Security.Claims;


/// <summary>
/// Adds Admin-specific claims to the JWT access token on every login / token refresh:
///   ouid   — Region OU Id (root of the OU tree the user belongs to)
///   teamid — Team OU Id  (direct OU the user is a member of, when it has a parent)
/// </summary>
[Dependency(ServiceLifetime.Transient)]
//[ExposeServices(typeof(DmsClaimsPrincipalContributor), typeof(IAbpClaimsPrincipalContributor))]
public class OrganizationClaimsPrincipalContributor : IAbpClaimsPrincipalContributor, ITransientDependency
{
    public async Task ContributeAsync(AbpClaimsPrincipalContributorContext context)
    {
        var principal = context.ClaimsPrincipal;
        var userIdStr = principal.FindFirst(AbpClaimTypes.UserId)?.Value;
        if (string.IsNullOrEmpty(userIdStr) || !Guid.TryParse(userIdStr, out _)) return;

        var userManager = context.ServiceProvider.GetRequiredService<IdentityUserManager>();
        var user = await userManager.FindByIdAsync(userIdStr);
        if (user == null) return;

        var ous = await userManager.GetOrganizationUnitsAsync(user);
        if (ous.Count == 0) return;

        // Team OU has a parent; Region OU is the root (no parent).
        var teamOu = ous.FirstOrDefault(o => o.ParentId != null);
        var regionOu = ous.FirstOrDefault(o => o.ParentId == null);

        Guid? ouId = null;
        Guid? teamId = null;

        if (teamOu != null)
        {
            teamId = teamOu.Id;

            // Traverse up the OU tree until we reach the root (Region OU).
            var ouRepo = context.ServiceProvider.GetRequiredService<IOrganizationUnitRepository>();
            var current = teamOu;
            while (current.ParentId.HasValue)
                current = await ouRepo.GetAsync(current.ParentId.Value);

            ouId = current.Id;
        }
        else if (regionOu != null)
        {
            ouId = regionOu.Id;
        }

        var identity = principal.Identities.First();

        if (ouId.HasValue)
            identity.AddClaim(MakeClaim("ouid", ouId.Value.ToString()));

        if (teamId.HasValue)
            identity.AddClaim(MakeClaim("teamid", teamId.Value.ToString()));
    }

    private static Claim MakeClaim(string type, string value)
    {
        var claim = new Claim(type, value);
        claim.SetDestinations(OpenIddictConstants.Destinations.AccessToken);
        return claim;
    }
}
