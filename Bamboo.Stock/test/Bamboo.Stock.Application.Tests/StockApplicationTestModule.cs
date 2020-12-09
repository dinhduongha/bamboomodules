using Volo.Abp.Modularity;

namespace Bamboo.Stock
{
    [DependsOn(
        typeof(StockApplicationModule),
        typeof(StockDomainTestModule)
        )]
    public class StockApplicationTestModule : AbpModule
    {

    }
}
