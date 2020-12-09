using Bamboo.Product.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Bamboo.Product
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(ProductEntityFrameworkCoreTestModule)
        )]
    public class ProductDomainTestModule : AbpModule
    {
        
    }
}
