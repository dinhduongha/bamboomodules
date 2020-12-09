using Volo.Abp.Modularity;

namespace Bamboo.Attendance
{
    [DependsOn(
        typeof(AttendanceApplicationModule),
        typeof(AttendanceDomainTestModule)
        )]
    public class AttendanceApplicationTestModule : AbpModule
    {

    }
}
