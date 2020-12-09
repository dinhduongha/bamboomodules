using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Bamboo.Stock
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(StockDomainSharedModule)
    )]
    public class StockDomainModule : AbpModule
    {

    }
}
