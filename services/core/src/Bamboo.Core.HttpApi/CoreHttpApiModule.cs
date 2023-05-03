using Localization.Resources.AbpUi;
using Bamboo.Core.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Bamboo.Core;

[DependsOn(
    typeof(CoreApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class CoreHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(CoreHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<CoreResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
