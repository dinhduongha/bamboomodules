using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Fleet
{
    public class BambooFleetSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooFleetSharedModule).GetAssembly());
        }
    }
}