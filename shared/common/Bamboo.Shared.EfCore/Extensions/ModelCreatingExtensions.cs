using Microsoft.EntityFrameworkCore;
using Volo.Abp;

public static class DbContextModelCreatingExtensions
{
	/*
	    builder.InitPostgreSQLExtension();

        base.OnModelCreating(builder);

        builder.ConfigureBamboo();
	*/
	
    public static void ConfigureBamboo(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(BambooConsts.DbTablePrefix + "YourEntities", BambooConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});

		builder.UseIdentityColumns();
        builder.UseSerialColumns();
        builder.StringSize();
        builder.PostgreSQLDataType();
        //builder.SnakeCase();
        // Change to lower case:
        // https://github.com/abpframework/abp/issues/2131
    }
}