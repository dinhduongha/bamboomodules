using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamboo.Employee
{
    [DependsOn(typeof(BambooEmployeeSharedModule))]
    public class BambooEmployeeModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BambooEmployeeModule).GetAssembly());
        }
    }
}