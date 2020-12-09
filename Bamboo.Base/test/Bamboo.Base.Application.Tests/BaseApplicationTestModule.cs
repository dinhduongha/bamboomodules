using Volo.Abp.Modularity;

namespace Bamboo.Base
{
    [DependsOn(
        typeof(BaseApplicationModule),
        typeof(BaseDomainTestModule)
        )]
    public class BaseApplicationTestModule : AbpModule
    {

    }
}
