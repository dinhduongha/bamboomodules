using Bamboo.CRM.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Bamboo.CRM.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class CRMPageModel : AbpPageModel
    {
        protected CRMPageModel()
        {
            LocalizationResourceType = typeof(CRMResource);
            ObjectMapperContext = typeof(CRMWebModule);
        }
    }
}