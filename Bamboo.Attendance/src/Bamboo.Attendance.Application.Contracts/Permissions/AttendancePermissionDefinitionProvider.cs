using Bamboo.Attendance.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Bamboo.Attendance.Permissions
{
    public class AttendancePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(AttendancePermissions.GroupName, L("Permission:Attendance"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AttendanceResource>(name);
        }
    }
}