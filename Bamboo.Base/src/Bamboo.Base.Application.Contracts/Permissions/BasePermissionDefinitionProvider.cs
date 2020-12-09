using Bamboo.Base.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Bamboo.Base.Permissions
{
    public class BasePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(BasePermissions.GroupName, L("Permission:Base"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BaseResource>(name);
        }
    }
}