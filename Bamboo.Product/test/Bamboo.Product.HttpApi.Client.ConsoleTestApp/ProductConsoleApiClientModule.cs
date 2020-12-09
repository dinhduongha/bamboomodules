using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Bamboo.Product
{
    [DependsOn(
        typeof(ProductHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class ProductConsoleApiClientModule : AbpModule
    {
        
    }
}
