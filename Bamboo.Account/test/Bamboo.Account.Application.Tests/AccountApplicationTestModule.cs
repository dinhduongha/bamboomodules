using Volo.Abp.Modularity;

namespace Bamboo.Account
{
    [DependsOn(
        typeof(AccountApplicationModule),
        typeof(AccountDomainTestModule)
        )]
    public class AccountApplicationTestModule : AbpModule
    {

    }
}
