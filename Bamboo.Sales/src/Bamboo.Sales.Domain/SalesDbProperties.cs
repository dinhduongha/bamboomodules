namespace Bamboo.Sales
{
    public static class SalesDbProperties
    {
        public static string DbTablePrefix { get; set; } = "Sales";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "Sales";
    }
}
