using Bamboo.CRM.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Bamboo.CRM.Pages
{
    public abstract class CRMPageModel : AbpPageModel
    {
        protected CRMPageModel()
        {
            LocalizationResourceType = typeof(CRMResource);
        }
    }
}