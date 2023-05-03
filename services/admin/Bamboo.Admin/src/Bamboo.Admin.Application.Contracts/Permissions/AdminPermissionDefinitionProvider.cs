using Bamboo.Admin.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Bamboo.Admin.Permissions;

public class AdminPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AdminPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AdminPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AdminResource>(name);
    }
}
