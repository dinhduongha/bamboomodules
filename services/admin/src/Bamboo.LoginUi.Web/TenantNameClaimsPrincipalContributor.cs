using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Volo.Abp.Security.Claims;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Identity;
using Volo.Abp.TenantManagement;
using Volo.Abp.DependencyInjection;

public class TenantNameClaimsPrincipalContributor
    : IAbpClaimsPrincipalContributor, ITransientDependency
{
    private readonly ITenantRepository _tenantRepository;
    private readonly IIdentityUserRepository _userRepository;
    private readonly ICurrentTenant _currentTenant;

    public TenantNameClaimsPrincipalContributor(
        ITenantRepository tenantRepository,
        IIdentityUserRepository userRepository,
        ICurrentTenant currentTenant)
    {
        _tenantRepository = tenantRepository;
        _userRepository = userRepository;
        _currentTenant = currentTenant;
    }

    public async Task ContributeAsync(AbpClaimsPrincipalContributorContext context)
    {
        var identity = context.ClaimsPrincipal.Identity as ClaimsIdentity;
        if (identity == null || !identity.IsAuthenticated)
            return;

        var userIdClaim = identity.FindFirst(AbpClaimTypes.UserId);
        if (userIdClaim == null)
            return;

        if (!Guid.TryParse(userIdClaim.Value, out var userId))
            return;

        var user = await _userRepository.FindAsync(userId);

        if (user == null)
            return;

        var isTenantUser = user.TenantId.HasValue;
        if (isTenantUser)
        {
            if (!identity.HasClaim(c => c.Type == "tenant_user"))
            {
                identity.AddClaim(
                    new Claim("tenant_user", "true")
                );
            }
        }
        if (!_currentTenant.IsAvailable)
        {
            return;
        }
        if (identity.HasClaim(c => c.Type == "tenant_name"))
        {
            return;
        }

        var tenant = await _tenantRepository.FindAsync(_currentTenant.Id!.Value);
        if (tenant == null)
        {
            return;
        }
        identity.AddClaim(new Claim("tenant_name", tenant.Name));
        using (_currentTenant.Change(tenant?.Id, tenant.Name))
        {
            var ous = await _userRepository.GetOrganizationUnitsAsync(user.Id);
            if (ous.Any())
            {
                identity.AddClaim(
                    new Claim(
                        "ous",
                        string.Join(",", ous.Select(x => x.Id))
                    )
                );
            }
        }
    }

}
