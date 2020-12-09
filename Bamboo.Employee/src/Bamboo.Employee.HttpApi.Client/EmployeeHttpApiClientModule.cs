using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Bamboo.Employee
{
    [DependsOn(
        typeof(EmployeeApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class EmployeeHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Employee";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(EmployeeApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
