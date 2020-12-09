using Bamboo.Employee.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Bamboo.Employee
{
    public abstract class EmployeeController : AbpController
    {
        protected EmployeeController()
        {
            LocalizationResource = typeof(EmployeeResource);
        }
    }
}
