using Bamboo.Employee.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Bamboo.Employee.Permissions
{
    public class EmployeePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(EmployeePermissions.GroupName, L("Permission:Employee"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<EmployeeResource>(name);
        }
    }
}