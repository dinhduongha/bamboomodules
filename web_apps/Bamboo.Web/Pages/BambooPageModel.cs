using Bamboo.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Bamboo.Web.Pages;

public abstract class BambooPageModel : AbpPageModel
{
    protected BambooPageModel()
    {
        LocalizationResourceType = typeof(BambooResource);
    }
}
