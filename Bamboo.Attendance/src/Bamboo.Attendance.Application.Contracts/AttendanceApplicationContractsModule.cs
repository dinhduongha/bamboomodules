using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Bamboo.Attendance
{
    [DependsOn(
        typeof(AttendanceDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class AttendanceApplicationContractsModule : AbpModule
    {

    }
}
