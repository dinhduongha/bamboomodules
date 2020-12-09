using Bamboo.Account.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Bamboo.Account.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class AccountPageModel : AbpPageModel
    {
        protected AccountPageModel()
        {
            LocalizationResourceType = typeof(AccountResource);
            ObjectMapperContext = typeof(AccountWebModule);
        }
    }
}