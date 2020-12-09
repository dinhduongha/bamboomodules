using Bamboo.Account.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Bamboo.Account.Pages
{
    public abstract class AccountPageModel : AbpPageModel
    {
        protected AccountPageModel()
        {
            LocalizationResourceType = typeof(AccountResource);
        }
    }
}