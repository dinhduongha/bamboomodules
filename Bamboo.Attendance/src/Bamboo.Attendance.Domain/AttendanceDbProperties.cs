namespace Bamboo.Attendance
{
    public static class AttendanceDbProperties
    {
        public static string DbTablePrefix { get; set; } = "Attendance";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "Attendance";
    }
}
