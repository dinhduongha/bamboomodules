using Bamboo.Product.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Bamboo.Product
{
    public abstract class ProductController : AbpController
    {
        protected ProductController()
        {
            LocalizationResource = typeof(ProductResource);
        }
    }
}
