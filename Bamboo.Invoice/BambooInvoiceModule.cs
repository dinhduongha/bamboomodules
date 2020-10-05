using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Invoice
{
    [DependsOn(typeof(BambooInvoiceSharedModule))]
    public class BambooInvoiceModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooInvoiceModule).GetAssembly());
        }
    }
}