using Volo.Abp.Reflection;

namespace Bamboo.CRM.Permissions
{
    public class CRMPermissions
    {
        public const string GroupName = "CRM";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(CRMPermissions));
        }
    }
}