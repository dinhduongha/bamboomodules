using Bamboo.Sales.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Bamboo.Sales
{
    public abstract class SalesController : AbpController
    {
        protected SalesController()
        {
            LocalizationResource = typeof(SalesResource);
        }
    }
}
