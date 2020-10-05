using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Invoice
{
    public class BambooInvoiceSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooInvoiceSharedModule).GetAssembly());
        }
    }
}