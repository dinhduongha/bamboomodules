using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Bamboo.Core;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(CoreDomainSharedModule)
)]
public class CoreDomainModule : AbpModule
{

}
