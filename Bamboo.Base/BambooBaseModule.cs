using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Base
{
    [DependsOn(typeof(BambooBaseSharedModule))]
    public class BambooBaseModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooBaseModule).GetAssembly());
        }
    }
}