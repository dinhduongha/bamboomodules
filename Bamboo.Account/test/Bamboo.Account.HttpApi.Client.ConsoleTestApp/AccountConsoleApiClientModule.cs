using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Bamboo.Account
{
    [DependsOn(
        typeof(AccountHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class AccountConsoleApiClientModule : AbpModule
    {
        
    }
}
