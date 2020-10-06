using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Document
{
    public class BambooDocumentSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooDocumentSharedModule).GetAssembly());
        }
    }
}