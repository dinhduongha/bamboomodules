using Localization.Resources.AbpUi;
using Bamboo.CRM.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Bamboo.CRM
{
    [DependsOn(
        typeof(CRMApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class CRMHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(CRMHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<CRMResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
