using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Mrp
{
    public class BambooMrpSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooMrpSharedModule).GetAssembly());
        }
    }
}