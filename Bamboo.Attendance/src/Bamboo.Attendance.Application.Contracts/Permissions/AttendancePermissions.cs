using Volo.Abp.Reflection;

namespace Bamboo.Attendance.Permissions
{
    public class AttendancePermissions
    {
        public const string GroupName = "Attendance";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(AttendancePermissions));
        }
    }
}