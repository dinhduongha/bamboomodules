using Bamboo.Core.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Bamboo.Core.Pages;

public abstract class CorePageModel : AbpPageModel
{
    protected CorePageModel()
    {
        LocalizationResourceType = typeof(CoreResource);
    }
}
