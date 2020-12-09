using Bamboo.Product.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Bamboo.Product.Pages
{
    public abstract class ProductPageModel : AbpPageModel
    {
        protected ProductPageModel()
        {
            LocalizationResourceType = typeof(ProductResource);
        }
    }
}