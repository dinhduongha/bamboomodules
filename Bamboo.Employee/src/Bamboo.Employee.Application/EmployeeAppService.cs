using Bamboo.Employee.Localization;
using Volo.Abp.Application.Services;

namespace Bamboo.Employee
{
    public abstract class EmployeeAppService : ApplicationService
    {
        protected EmployeeAppService()
        {
            LocalizationResource = typeof(EmployeeResource);
            ObjectMapperContext = typeof(EmployeeApplicationModule);
        }
    }
}
