using Volo.Abp.Reflection;

namespace Bamboo.Sales.Permissions
{
    public class SalesPermissions
    {
        public const string GroupName = "Sales";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(SalesPermissions));
        }
    }
}