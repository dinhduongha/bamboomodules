using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Bamboo.Stock
{
    [DependsOn(
        typeof(StockDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class StockApplicationContractsModule : AbpModule
    {

    }
}
