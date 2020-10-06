using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Hr
{
    [DependsOn(typeof(BambooHrSharedModule))]
    public class BambooHrModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooHrModule).GetAssembly());
        }
    }
}