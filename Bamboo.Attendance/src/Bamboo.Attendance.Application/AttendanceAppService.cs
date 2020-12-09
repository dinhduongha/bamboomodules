using Bamboo.Attendance.Localization;
using Volo.Abp.Application.Services;

namespace Bamboo.Attendance
{
    public abstract class AttendanceAppService : ApplicationService
    {
        protected AttendanceAppService()
        {
            LocalizationResource = typeof(AttendanceResource);
            ObjectMapperContext = typeof(AttendanceApplicationModule);
        }
    }
}
