using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Document
{
    [DependsOn(typeof(BambooDocumentSharedModule))]
    public class BambooDocumentModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooDocumentModule).GetAssembly());
        }
    }
}