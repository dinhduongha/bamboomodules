using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.POS
{
    [DependsOn(typeof(BambooPOSSharedModule))]
    public class BambooPOSModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooPOSModule).GetAssembly());
        }
    }
}