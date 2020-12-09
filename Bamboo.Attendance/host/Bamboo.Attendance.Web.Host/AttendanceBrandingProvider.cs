using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Bamboo.Attendance
{
    [Dependency(ReplaceServices = true)]
    public class AttendanceBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Attendance";
    }
}
