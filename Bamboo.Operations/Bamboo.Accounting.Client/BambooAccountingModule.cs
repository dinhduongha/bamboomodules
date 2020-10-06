using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Accounting
{
    [DependsOn(typeof(BambooAccountingSharedModule))]
    public class BambooAccountingModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooAccountingModule).GetAssembly());
        }
    }
}