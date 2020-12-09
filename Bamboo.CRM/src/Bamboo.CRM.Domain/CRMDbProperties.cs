namespace Bamboo.CRM
{
    public static class CRMDbProperties
    {
        public static string DbTablePrefix { get; set; } = "CRM";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "CRM";
    }
}
