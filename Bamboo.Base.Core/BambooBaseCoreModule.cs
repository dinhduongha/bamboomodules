using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Base.Core
{
    public class BambooBaseCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooBaseCoreModule).GetAssembly());
        }
    }
}