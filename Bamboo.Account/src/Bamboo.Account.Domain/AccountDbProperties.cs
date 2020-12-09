namespace Bamboo.Account
{
    public static class AccountDbProperties
    {
        public static string DbTablePrefix { get; set; } = "Account";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "Account";
    }
}
