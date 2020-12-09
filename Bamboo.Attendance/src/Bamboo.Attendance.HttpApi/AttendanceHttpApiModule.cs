using Localization.Resources.AbpUi;
using Bamboo.Attendance.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Bamboo.Attendance
{
    [DependsOn(
        typeof(AttendanceApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class AttendanceHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(AttendanceHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<AttendanceResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
