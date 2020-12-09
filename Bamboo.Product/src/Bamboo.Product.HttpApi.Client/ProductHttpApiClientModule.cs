using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Bamboo.Product
{
    [DependsOn(
        typeof(ProductApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class ProductHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Product";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(ProductApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
