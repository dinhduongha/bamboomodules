using Volo.Abp.Reflection;

namespace Bamboo.Employee.Permissions
{
    public class EmployeePermissions
    {
        public const string GroupName = "Employee";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(EmployeePermissions));
        }
    }
}