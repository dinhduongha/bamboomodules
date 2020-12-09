using Bamboo.Employee.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Bamboo.Employee.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class EmployeePageModel : AbpPageModel
    {
        protected EmployeePageModel()
        {
            LocalizationResourceType = typeof(EmployeeResource);
            ObjectMapperContext = typeof(EmployeeWebModule);
        }
    }
}