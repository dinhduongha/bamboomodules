using Bamboo.Stock.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Bamboo.Stock.Pages
{
    public abstract class StockPageModel : AbpPageModel
    {
        protected StockPageModel()
        {
            LocalizationResourceType = typeof(StockResource);
        }
    }
}