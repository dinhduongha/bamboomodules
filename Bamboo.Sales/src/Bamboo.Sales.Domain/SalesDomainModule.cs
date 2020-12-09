using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Bamboo.Sales
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(SalesDomainSharedModule)
    )]
    public class SalesDomainModule : AbpModule
    {

    }
}
