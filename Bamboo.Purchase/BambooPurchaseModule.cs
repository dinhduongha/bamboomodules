using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Purchase
{
    [DependsOn(typeof(BambooPurchaseSharedModule))]
    public class BambooPurchaseModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooPurchaseModule).GetAssembly());
        }
    }
}