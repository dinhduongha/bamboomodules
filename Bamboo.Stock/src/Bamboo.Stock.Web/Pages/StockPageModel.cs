using Bamboo.Stock.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Bamboo.Stock.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class StockPageModel : AbpPageModel
    {
        protected StockPageModel()
        {
            LocalizationResourceType = typeof(StockResource);
            ObjectMapperContext = typeof(StockWebModule);
        }
    }
}