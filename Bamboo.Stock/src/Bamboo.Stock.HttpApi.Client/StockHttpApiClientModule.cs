using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Bamboo.Stock
{
    [DependsOn(
        typeof(StockApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class StockHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Stock";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(StockApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
