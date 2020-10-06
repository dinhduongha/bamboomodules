using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Base
{
    public class BambooBaseSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooBaseSharedModule).GetAssembly());
        }
    }
}