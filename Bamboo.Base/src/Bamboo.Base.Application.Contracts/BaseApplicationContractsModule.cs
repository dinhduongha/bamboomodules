using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Bamboo.Base
{
    [DependsOn(
        typeof(BaseDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class BaseApplicationContractsModule : AbpModule
    {

    }
}
