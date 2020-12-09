using Bamboo.Sales.Localization;
using Volo.Abp.Application.Services;

namespace Bamboo.Sales
{
    public abstract class SalesAppService : ApplicationService
    {
        protected SalesAppService()
        {
            LocalizationResource = typeof(SalesResource);
            ObjectMapperContext = typeof(SalesApplicationModule);
        }
    }
}
