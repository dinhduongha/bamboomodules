using Bamboo.Base.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Bamboo.Base.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class BasePageModel : AbpPageModel
    {
        protected BasePageModel()
        {
            LocalizationResourceType = typeof(BaseResource);
            ObjectMapperContext = typeof(BaseWebModule);
        }
    }
}