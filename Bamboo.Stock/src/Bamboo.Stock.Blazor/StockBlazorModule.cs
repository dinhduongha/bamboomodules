using Microsoft.Extensions.DependencyInjection;
using Bamboo.Stock.Blazor.Menus;
using Volo.Abp.AspNetCore.Components.WebAssembly.Theming.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace Bamboo.Stock.Blazor
{
    [DependsOn(
        typeof(StockHttpApiClientModule),
        typeof(AbpAutoMapperModule)
        )]
    public class StockBlazorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<StockBlazorModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<StockBlazorAutoMapperProfile>(validate: true);
            });

            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new StockMenuContributor());
            });

            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(StockBlazorModule).Assembly);
            });
        }
    }
}