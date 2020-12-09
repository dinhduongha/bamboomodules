using Localization.Resources.AbpUi;
using Bamboo.Base.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Bamboo.Base
{
    [DependsOn(
        typeof(BaseApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class BaseHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(BaseHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<BaseResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
