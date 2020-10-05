using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Hr
{
    public class BambooHrSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooHrSharedModule).GetAssembly());
        }
    }
}