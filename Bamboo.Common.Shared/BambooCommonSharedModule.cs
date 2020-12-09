//using Abp.Modules;
//using Abp.Reflection.Extensions;
using Volo.Abp.Modularity;
namespace Bamboo.Common
{
    public class BambooCommonSharedModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            //PreConfigure<IMvcBuilder>(mvcBuilder =>
            //{
            //    mvcBuilder.AddApplicationPartIfNotExists(typeof(IOTHttpApiModule).Assembly);
            //});
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //Configure<AbpLocalizationOptions>(options =>
            //{
            //    options.Resources
            //        .Get<IOTResource>()
            //        .AddBaseTypes(typeof(AbpUiResource));
            //});
        }
    }
}