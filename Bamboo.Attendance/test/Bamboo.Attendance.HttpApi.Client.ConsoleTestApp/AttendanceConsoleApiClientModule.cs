using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Bamboo.Attendance
{
    [DependsOn(
        typeof(AttendanceHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class AttendanceConsoleApiClientModule : AbpModule
    {
        
    }
}
