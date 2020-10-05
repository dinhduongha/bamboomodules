using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Sale
{
    public class BambooSaleSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooSaleSharedModule).GetAssembly());
        }
    }
}