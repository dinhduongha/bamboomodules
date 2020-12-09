using Volo.Abp.Modularity;

namespace Bamboo.Employee
{
    [DependsOn(
        typeof(EmployeeApplicationModule),
        typeof(EmployeeDomainTestModule)
        )]
    public class EmployeeApplicationTestModule : AbpModule
    {

    }
}
