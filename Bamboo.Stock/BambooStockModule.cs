using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Stock
{
    [DependsOn(typeof(BambooStockSharedModule))]
    public class BambooStockModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooStockModule).GetAssembly());
        }
    }
}