using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Bamboo.Attendance
{
    [DependsOn(
        typeof(AttendanceApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class AttendanceHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Attendance";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(AttendanceApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
