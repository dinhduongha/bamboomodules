using Bamboo.Stock.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Bamboo.Stock
{
    public abstract class StockController : AbpController
    {
        protected StockController()
        {
            LocalizationResource = typeof(StockResource);
        }
    }
}
