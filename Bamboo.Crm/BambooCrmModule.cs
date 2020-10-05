using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Crm
{
    [DependsOn(typeof(BambooCrmSharedModule))]
    public class BambooCrmModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooCrmModule).GetAssembly());
        }
    }
}