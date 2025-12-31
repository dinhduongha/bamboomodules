using System.Security.Claims;
using System.Threading.Tasks;
using Volo.Abp.Security.Claims;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;
using Volo.Abp.DependencyInjection;

public class TenantNameClaimsPrincipalContributor
    : IAbpClaimsPrincipalContributor, ITransientDependency
{
    private readonly ITenantRepository _tenantRepository;
    private readonly ICurrentTenant _currentTenant;

    public TenantNameClaimsPrincipalContributor(
        ITenantRepository tenantRepository,
        ICurrentTenant currentTenant)
    {
        _tenantRepository = tenantRepository;
        _currentTenant = currentTenant;
    }

    public async Task ContributeAsync(AbpClaimsPrincipalContributorContext context)
    {
        if (!_currentTenant.IsAvailable)
        {
            return;
        }

        var identity = context.ClaimsPrincipal.Identity as ClaimsIdentity;
        if (identity == null)
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
    }

}
