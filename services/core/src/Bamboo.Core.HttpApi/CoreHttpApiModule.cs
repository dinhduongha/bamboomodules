using Localization.Resources.AbpUi;
using Bamboo.Core.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

using Bamboo.Core.HttpApi;

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
        // context.Services.AddTransient<IGenericEntityAppService<SaleOrder>, GenericAppService<SaleOrder>>();
        // context.Services.AddTransient<IGenericEntityAppService<ResPartner>, GenericAppService<ResPartner>>();
        // context.Services.AddTransient<IGenericEntityAppService<SaleOrderLine>, GenericAppService<SaleOrderLine>>();
        // context.Services.AddTransient<IGenericEntityAppService<ProductTag>, GenericAppService<ProductTag>>();
        context.Services.AddTransient<DynamicGenericController>();
    }
}
