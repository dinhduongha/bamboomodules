using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Bamboo.CRM
{
    [DependsOn(
        typeof(CRMHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class CRMConsoleApiClientModule : AbpModule
    {
        
    }
}
