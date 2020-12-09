using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Bamboo.Base
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(BaseDomainSharedModule)
    )]
    public class BaseDomainModule : AbpModule
    {

    }
}
