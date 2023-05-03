using Bamboo.Admin.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Bamboo.Admin;

[DependsOn(
    typeof(AdminEntityFrameworkCoreTestModule)
    )]
public class AdminDomainTestModule : AbpModule
{

}
