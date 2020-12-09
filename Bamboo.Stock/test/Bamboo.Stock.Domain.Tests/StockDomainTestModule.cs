using Bamboo.Stock.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Bamboo.Stock
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(StockEntityFrameworkCoreTestModule)
        )]
    public class StockDomainTestModule : AbpModule
    {
        
    }
}
