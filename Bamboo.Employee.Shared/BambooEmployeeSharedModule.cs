using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Employee
{
    public class BambooEmployeeSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooEmployeeSharedModule).GetAssembly());
        }
    }
}