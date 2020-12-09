using Bamboo.Attendance.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Bamboo.Attendance
{
    public abstract class AttendanceController : AbpController
    {
        protected AttendanceController()
        {
            LocalizationResource = typeof(AttendanceResource);
        }
    }
}
