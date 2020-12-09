using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace Bamboo.Stock
{
    [DependsOn(
        typeof(StockDomainModule),
        typeof(StockApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule)
        )]
    public class StockApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<StockApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<StockApplicationModule>(validate: true);
            });
        }
    }
}
