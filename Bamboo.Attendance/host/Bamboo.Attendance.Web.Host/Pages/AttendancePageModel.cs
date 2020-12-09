using Bamboo.Attendance.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Bamboo.Attendance.Pages
{
    public abstract class AttendancePageModel : AbpPageModel
    {
        protected AttendancePageModel()
        {
            LocalizationResourceType = typeof(AttendanceResource);
        }
    }
}