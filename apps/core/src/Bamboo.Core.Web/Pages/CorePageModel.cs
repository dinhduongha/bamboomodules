using Bamboo.Core.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Bamboo.Core.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class CorePageModel : AbpPageModel
{
    protected CorePageModel()
    {
        LocalizationResourceType = typeof(CoreResource);
        ObjectMapperContext = typeof(CoreWebModule);
    }
}
