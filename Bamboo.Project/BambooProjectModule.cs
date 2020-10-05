using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Project
{
    [DependsOn(typeof(BambooProjectSharedModule))]
    public class BambooProjectModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooProjectModule).GetAssembly());
        }
    }
}