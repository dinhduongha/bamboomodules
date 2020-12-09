using Volo.Abp.Modularity;

namespace Bamboo.Sales
{
    [DependsOn(
        typeof(SalesApplicationModule),
        typeof(SalesDomainTestModule)
        )]
    public class SalesApplicationTestModule : AbpModule
    {

    }
}
