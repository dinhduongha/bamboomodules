using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Crm
{
    public class BambooCrmSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooCrmSharedModule).GetAssembly());
        }
    }
}