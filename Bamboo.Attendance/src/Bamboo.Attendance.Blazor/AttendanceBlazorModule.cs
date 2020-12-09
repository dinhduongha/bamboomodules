using Microsoft.Extensions.DependencyInjection;
using Bamboo.Attendance.Blazor.Menus;
using Volo.Abp.AspNetCore.Components.WebAssembly.Theming.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace Bamboo.Attendance.Blazor
{
    [DependsOn(
        typeof(AttendanceHttpApiClientModule),
        typeof(AbpAutoMapperModule)
        )]
    public class AttendanceBlazorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<AttendanceBlazorModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<AttendanceBlazorAutoMapperProfile>(validate: true);
            });

            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new AttendanceMenuContributor());
            });

            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(AttendanceBlazorModule).Assembly);
            });
        }
    }
}