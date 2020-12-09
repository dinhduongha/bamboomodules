using Bamboo.Sales.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Bamboo.Sales.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class SalesPageModel : AbpPageModel
    {
        protected SalesPageModel()
        {
            LocalizationResourceType = typeof(SalesResource);
            ObjectMapperContext = typeof(SalesWebModule);
        }
    }
}