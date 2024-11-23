using Bamboo.Admin;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

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

        builder.Entity<TenantOwner>(b =>
        {
            b.ToTable("AbpTenants")
             .HasIndex(b => b.OwnerId);
            b.ConfigureByConvention(); //auto configure for the base class props
            //...
        });
        builder.Entity<BranchUser>(b =>
        {
            b.ToTable("AbpUsers").HasIndex(b=>b.BranchId);
            b.ConfigureByConvention(); //auto configure for the base class props
            //...
        });

        builder.Entity<RolesExtra>(b =>
        {
            b.ToTable("AbpRoles").HasIndex(b => b.BranchId);
            b.ConfigureByConvention(); //auto configure for the base class props
            //...
        });

        builder.Entity<UserLoginExtra>(b =>
        {
            b.ToTable("AbpUserLogins");
            b.ConfigureByConvention(); //auto configure for the base class props
            //...
        });

        builder.Entity<Branch>(b =>
        {
            b.ToTable("Branch");
            b.ConfigureByConvention(); //auto configure for the base class props
            //...
        });
        
        builder.Entity<BranchOrganizationUnit>(b =>
        {
            b.ToTable("AbpOrganizationUnits");
            b.ConfigureByConvention(); //auto configure for the base class props
            //...
        });

        builder.Entity<BranchOrganizationUnitRole>(b =>
        {
            b.ToTable("AbpOrganizationUnitRoles");
            b.ConfigureByConvention(); //auto configure for the base class props
            //...
        });

        builder.Entity<BranchUserOrganizationUnit>(b =>
        {
            b.ToTable("AbpUserOrganizationUnits");
            b.ConfigureByConvention(); //auto configure for the base class props
            //...
        });

        builder.Entity<BranchUserClaim>(b =>
        {
            b.ToTable("AbpUserClaims");
            b.ConfigureByConvention(); //auto configure for the base class props
            //...
        });

        //builder.Entity<OpenIddictApplicationExtra>(b =>
        //{
        //    b.ToTable("OpenIddictApplications").HasIndex(b => b.TenantId);
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