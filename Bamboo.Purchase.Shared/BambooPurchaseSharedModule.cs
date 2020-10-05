using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Purchase
{
    public class BambooPurchaseSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooPurchaseSharedModule).GetAssembly());
        }
    }
}