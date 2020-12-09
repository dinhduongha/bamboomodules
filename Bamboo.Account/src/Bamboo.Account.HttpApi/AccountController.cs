using Bamboo.Account.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Bamboo.Account
{
    public abstract class AccountController : AbpController
    {
        protected AccountController()
        {
            LocalizationResource = typeof(AccountResource);
        }
    }
}
