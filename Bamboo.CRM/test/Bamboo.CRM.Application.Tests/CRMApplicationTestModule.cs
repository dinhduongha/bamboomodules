using Volo.Abp.Modularity;

namespace Bamboo.CRM
{
    [DependsOn(
        typeof(CRMApplicationModule),
        typeof(CRMDomainTestModule)
        )]
    public class CRMApplicationTestModule : AbpModule
    {

    }
}
