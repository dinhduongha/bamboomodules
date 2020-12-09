using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Bamboo.Attendance
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(AttendanceDomainSharedModule)
    )]
    public class AttendanceDomainModule : AbpModule
    {

    }
}
