using Volo.Abp.Reflection;

namespace Bamboo.Stock.Permissions
{
    public class StockPermissions
    {
        public const string GroupName = "Stock";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(StockPermissions));
        }
    }
}