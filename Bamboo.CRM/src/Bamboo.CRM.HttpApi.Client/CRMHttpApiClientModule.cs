using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Bamboo.CRM
{
    [DependsOn(
        typeof(CRMApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class CRMHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "CRM";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(CRMApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
