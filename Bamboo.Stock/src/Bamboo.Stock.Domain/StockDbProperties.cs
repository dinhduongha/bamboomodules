namespace Bamboo.Stock
{
    public static class StockDbProperties
    {
        public static string DbTablePrefix { get; set; } = "Stock";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "Stock";
    }
}
