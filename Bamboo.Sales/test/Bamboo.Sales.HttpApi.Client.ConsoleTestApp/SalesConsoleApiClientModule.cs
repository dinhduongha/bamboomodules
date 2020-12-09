using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Bamboo.Sales
{
    [DependsOn(
        typeof(SalesHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class SalesConsoleApiClientModule : AbpModule
    {
        
    }
}
