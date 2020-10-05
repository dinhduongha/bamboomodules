using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Stock
{
    public class BambooStockSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooStockSharedModule).GetAssembly());
        }
    }
}