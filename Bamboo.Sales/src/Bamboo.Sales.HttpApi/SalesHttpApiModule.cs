using Localization.Resources.AbpUi;
using Bamboo.Sales.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Bamboo.Sales
{
    [DependsOn(
        typeof(SalesApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class SalesHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(SalesHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<SalesResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
