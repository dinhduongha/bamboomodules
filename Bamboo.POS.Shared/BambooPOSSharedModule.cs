using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.POS
{
    public class BambooPOSSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooPOSSharedModule).GetAssembly());
        }
    }
}