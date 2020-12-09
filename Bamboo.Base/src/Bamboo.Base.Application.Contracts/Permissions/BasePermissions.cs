using Volo.Abp.Reflection;

namespace Bamboo.Base.Permissions
{
    public class BasePermissions
    {
        public const string GroupName = "Base";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(BasePermissions));
        }
    }
}