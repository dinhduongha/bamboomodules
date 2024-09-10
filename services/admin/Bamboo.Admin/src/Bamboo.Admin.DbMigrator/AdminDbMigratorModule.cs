using Bamboo.Admin.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.Modularity;

namespace Bamboo.Admin.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    //typeof(AbpCachingStackExchangeRedisModule),
    typeof(AdminEntityFrameworkCoreModule),
    typeof(AdminApplicationContractsModule)
    )]
public class AdminDbMigratorModule : AbpModule
{
}
