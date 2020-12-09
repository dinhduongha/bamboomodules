using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Bamboo.Employee
{
    [Dependency(ReplaceServices = true)]
    public class EmployeeBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Employee";
    }
}
