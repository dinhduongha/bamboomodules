using Volo.Abp.Modularity;

namespace Bamboo.Core;

[DependsOn(
    typeof(CoreApplicationModule),
    typeof(CoreDomainTestModule)
    )]
public class CoreApplicationTestModule : AbpModule
{

}
