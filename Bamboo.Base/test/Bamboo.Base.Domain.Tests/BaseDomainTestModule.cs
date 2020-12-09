using Bamboo.Base.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Bamboo.Base
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(BaseEntityFrameworkCoreTestModule)
        )]
    public class BaseDomainTestModule : AbpModule
    {
        
    }
}
