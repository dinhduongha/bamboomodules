using Bamboo.Product.Localization;
using Volo.Abp.Application.Services;

namespace Bamboo.Product
{
    public abstract class ProductAppService : ApplicationService
    {
        protected ProductAppService()
        {
            LocalizationResource = typeof(ProductResource);
            ObjectMapperContext = typeof(ProductApplicationModule);
        }
    }
}
