using Bamboo.Admin.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Bamboo.Admin.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AdminEntityFrameworkCoreModule),
    typeof(AdminApplicationContractsModule)
    )]
public class AdminDbMigratorModule : AbpModule
{

}
