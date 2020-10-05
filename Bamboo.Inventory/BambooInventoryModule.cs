using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Inventory
{
    [DependsOn(typeof(BambooInventorySharedModule))]
    public class BambooInventoryModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooInventoryModule).GetAssembly());
        }
    }
}