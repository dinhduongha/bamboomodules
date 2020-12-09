using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Bamboo.Sales
{
    [DependsOn(
        typeof(SalesApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class SalesHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Sales";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(SalesApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
