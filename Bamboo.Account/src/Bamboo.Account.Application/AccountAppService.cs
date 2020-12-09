using Bamboo.Account.Localization;
using Volo.Abp.Application.Services;

namespace Bamboo.Account
{
    public abstract class AccountAppService : ApplicationService
    {
        protected AccountAppService()
        {
            LocalizationResource = typeof(AccountResource);
            ObjectMapperContext = typeof(AccountApplicationModule);
        }
    }
}
