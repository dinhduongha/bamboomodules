using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Common
{
    public class BambooCommonSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooCommonSharedModule).GetAssembly());
        }
    }
}