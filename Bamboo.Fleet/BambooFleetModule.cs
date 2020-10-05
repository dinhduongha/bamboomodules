using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Fleet
{
    [DependsOn(typeof(BambooFleetSharedModule))]
    public class BambooFleetModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooFleetModule).GetAssembly());
        }
    }
}