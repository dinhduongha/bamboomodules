using Bamboo.Employee.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Bamboo.Employee.Pages
{
    public abstract class EmployeePageModel : AbpPageModel
    {
        protected EmployeePageModel()
        {
            LocalizationResourceType = typeof(EmployeeResource);
        }
    }
}