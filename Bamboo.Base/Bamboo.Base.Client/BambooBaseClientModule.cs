using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Base.Client
{
    [DependsOn(typeof(BambooBaseSharedModule))]
    public class BambooBaseClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooBaseClientModule).GetAssembly());
        }
    }
}