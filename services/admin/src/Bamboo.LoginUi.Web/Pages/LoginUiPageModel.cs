using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

using Bamboo.Abp.LoginUi.Web.Localization;
namespace Bamboo.Abp.LoginUi.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class LoginUiPageModel : AbpPageModel
{
    protected LoginUiPageModel()
    {
        LocalizationResourceType = typeof(AbpLoginUiResource);
        ObjectMapperContext = typeof(AbpLoginUiWebModule);
    }
}
