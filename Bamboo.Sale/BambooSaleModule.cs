using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Sale
{
    [DependsOn(typeof(BambooSaleSharedModule))]
    public class BambooSaleModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooSaleModule).GetAssembly());
        }
    }
}