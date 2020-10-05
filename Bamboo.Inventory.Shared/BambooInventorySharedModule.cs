using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Inventory
{
    public class BambooInventorySharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooInventorySharedModule).GetAssembly());
        }
    }
}