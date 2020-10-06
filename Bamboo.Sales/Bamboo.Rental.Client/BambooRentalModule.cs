using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Rental
{
    [DependsOn(typeof(BambooRentalSharedModule))]
    public class BambooRentalModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooRentalModule).GetAssembly());
        }
    }
}