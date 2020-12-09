using Localization.Resources.AbpUi;
using Bamboo.Employee.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Bamboo.Employee
{
    [DependsOn(
        typeof(EmployeeApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class EmployeeHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(EmployeeHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<EmployeeResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
