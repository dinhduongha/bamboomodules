using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Rental
{
    public class BambooRentalSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooRentalSharedModule).GetAssembly());
        }
    }
}