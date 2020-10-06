using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Accounting
{
    public class BambooAccountingSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooAccountingSharedModule).GetAssembly());
        }
    }
}