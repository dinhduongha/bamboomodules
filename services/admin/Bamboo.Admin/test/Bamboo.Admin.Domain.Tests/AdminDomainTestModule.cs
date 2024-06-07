using Volo.Abp.Modularity;

namespace Bamboo.Admin;

[DependsOn(
    typeof(AdminDomainModule),
    typeof(AdminTestBaseModule)
)]
public class AdminDomainTestModule : AbpModule
{

}
