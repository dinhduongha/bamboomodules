using Bamboo.Stock.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Bamboo.Stock.Permissions
{
    public class StockPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(StockPermissions.GroupName, L("Permission:Stock"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<StockResource>(name);
        }
    }
}