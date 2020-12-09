using Bamboo.Sales.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Bamboo.Sales.Permissions
{
    public class SalesPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(SalesPermissions.GroupName, L("Permission:Sales"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<SalesResource>(name);
        }
    }
}