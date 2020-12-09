using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Bamboo.Account
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(AccountDomainSharedModule)
    )]
    public class AccountDomainModule : AbpModule
    {

    }
}
