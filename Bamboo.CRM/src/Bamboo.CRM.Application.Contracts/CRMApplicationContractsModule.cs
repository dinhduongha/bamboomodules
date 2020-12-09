using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Bamboo.CRM
{
    [DependsOn(
        typeof(CRMDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class CRMApplicationContractsModule : AbpModule
    {

    }
}
