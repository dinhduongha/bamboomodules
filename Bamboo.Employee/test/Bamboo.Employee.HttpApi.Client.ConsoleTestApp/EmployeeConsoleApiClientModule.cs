using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Bamboo.Employee
{
    [DependsOn(
        typeof(EmployeeHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class EmployeeConsoleApiClientModule : AbpModule
    {
        
    }
}
