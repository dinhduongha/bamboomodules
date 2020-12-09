using Bamboo.Attendance.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Bamboo.Attendance.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class AttendancePageModel : AbpPageModel
    {
        protected AttendancePageModel()
        {
            LocalizationResourceType = typeof(AttendanceResource);
            ObjectMapperContext = typeof(AttendanceWebModule);
        }
    }
}