using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Bamboo.Stock
{
    [DependsOn(
        typeof(StockHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class StockConsoleApiClientModule : AbpModule
    {
        
    }
}
