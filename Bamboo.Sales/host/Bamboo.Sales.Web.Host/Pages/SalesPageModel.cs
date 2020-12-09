using Bamboo.Sales.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Bamboo.Sales.Pages
{
    public abstract class SalesPageModel : AbpPageModel
    {
        protected SalesPageModel()
        {
            LocalizationResourceType = typeof(SalesResource);
        }
    }
}