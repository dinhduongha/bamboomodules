using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Bamboo.Sales
{
    [DependsOn(
        typeof(SalesDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class SalesApplicationContractsModule : AbpModule
    {

    }
}
