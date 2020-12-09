namespace Bamboo.Employee
{
    public static class EmployeeDbProperties
    {
        public static string DbTablePrefix { get; set; } = "Employee";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "Employee";
    }
}
