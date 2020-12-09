using Localization.Resources.AbpUi;
using Bamboo.Stock.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Bamboo.Stock
{
    [DependsOn(
        typeof(StockApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class StockHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(StockHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<StockResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
