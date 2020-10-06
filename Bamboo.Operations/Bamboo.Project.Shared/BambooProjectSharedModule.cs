using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Project
{
    public class BambooProjectSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooProjectSharedModule).GetAssembly());
        }
    }
}