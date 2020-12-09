using Bamboo.Product.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Bamboo.Product.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class ProductPageModel : AbpPageModel
    {
        protected ProductPageModel()
        {
            LocalizationResourceType = typeof(ProductResource);
            ObjectMapperContext = typeof(ProductWebModule);
        }
    }
}