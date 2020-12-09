using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Bamboo.Employee
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(EmployeeDomainSharedModule)
    )]
    public class EmployeeDomainModule : AbpModule
    {

    }
}
