using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Mrp
{
    [DependsOn(typeof(BambooMrpSharedModule))]
    public class BambooMrpModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooMrpModule).GetAssembly());
        }
    }
}