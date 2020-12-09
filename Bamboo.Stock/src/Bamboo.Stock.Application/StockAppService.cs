using Bamboo.Stock.Localization;
using Volo.Abp.Application.Services;

namespace Bamboo.Stock
{
    public abstract class StockAppService : ApplicationService
    {
        protected StockAppService()
        {
            LocalizationResource = typeof(StockResource);
            ObjectMapperContext = typeof(StockApplicationModule);
        }
    }
}
