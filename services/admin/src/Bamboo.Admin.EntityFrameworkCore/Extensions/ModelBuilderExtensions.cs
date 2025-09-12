using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

//using Volo.Abp.EntityFrameworkCore.PostgreSql;
// <summary>
/// Converts <see cref="DateOnly" /> to <see cref="DateTime"/> and vice versa.
/// </summary>
public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
    /// <summary>
    /// Creates a new instance of this converter.
    /// </summary>
    public DateOnlyConverter() : base(
            d => d.ToDateTime(TimeOnly.MinValue),
            d => DateOnly.FromDateTime(d))
    { }
}

public class TimeOnlyConverter : ValueConverter<TimeOnly, TimeSpan>
{
    public TimeOnlyConverter() : base(
            timeOnly => timeOnly.ToTimeSpan(),
            timeSpan => TimeOnly.FromTimeSpan(timeSpan))
    {
    }
}
/*
In the DbContext we add the converters (coming up below)
https://github.com/karenpayneoregon/ef-core-dateonly-timeonly
protected override void ConfigureConventions(ModelConfigurationBuilder builder)
{

    builder.Properties<DateOnly>()
        .HaveConversion<DateOnlyConverter>()
        .HaveColumnType("date");

    builder.Properties<TimeOnly>()
        .HaveConversion<TimeOnlyConverter>()
        .HaveColumnType("time");

    base.ConfigureConventions(builder);

}
*/
public static partial class ModelConfigurationBuilderExtensions
{
    public static void ConfigureConventions(this ModelConfigurationBuilder builder)
    {
        builder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter>()
            .HaveColumnType("date");
    }
}

public static partial class DbContextOptionsBuilderExtensions
{
    public static void ConfigureConventions(this DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder
        //     .UseNpgsql()
        //     .UseSnakeCaseNamingConvention();
    }
}

public static partial class ModelBuilderExtensions
{
    public static ModelBuilder RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            entity.SetTableName(entity.DisplayName());
        }
        return modelBuilder;
    }
    /// <summary>
    /// https://andrewlock.net/customising-asp-net-core-identity-ef-core-naming-conventions-for-postgresql/
    /// https://github.com/aspnetboilerplate/aspnetboilerplate/issues/4959
    /// https://github.com/philfontaine/efcore-snakecase/commit/faf900fbfcb6f272f9729e2578d8bab722a115c7
    /// https://github.com/aspnet/EntityFrameworkCore/issues/18006
    /// </summary>
    /// <param name="builder"></param>
    public static ModelBuilder SnakeCase(this ModelBuilder builder)
    {
        //var entityTypes = builder.Model.GetEntityTypes().ToList();
        //foreach (var entityType in entityTypes)
        //{
        //    if (entityType.BaseType != null)
        //    {
        //        builder.Ignore(entityType.ClrType);
        //    }
        //}

        foreach (var entity in builder.Model.GetEntityTypes())
        {
            if (entity.BaseType == null)
            {
                entity.SetTableName(entity.GetTableName().ToSnakeCase());
            }
        }

        foreach (var entity in builder.Model.GetEntityTypes())
        {
            // Replace column names
            foreach (var property in entity.GetProperties())
            {
                var columnName = property.GetColumnName(StoreObjectIdentifier.Table(property.DeclaringEntityType.GetTableName(), null));
                property.SetColumnName(columnName.ToSnakeCase());
            }
            foreach (var key in entity.GetKeys())
            {
                key.SetName(key.GetName().ToSnakeCase());
            }

            foreach (var key in entity.GetForeignKeys())
            {
                key.SetConstraintName(key.GetConstraintName().ToSnakeCase());
            }

            foreach (var index in entity.GetIndexes())
            {
                //index.SetName(index.Name.ToSnakeCase());
                index.SetDatabaseName(index.Name.ToSnakeCase());
                
            }
        }
        return builder;
    }
    public static ModelBuilder PostgreSQLDataType(this ModelBuilder builder)
    {
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            foreach (var property in entity.GetProperties())
            {
                var fieldInfo = property.FieldInfo;
                if (fieldInfo != null)
                {
                    if (fieldInfo.FieldType == typeof(System.Nullable<System.DateTime>))
                    {
                        property.SetColumnType("timestamptz");
                    }
                    else if (fieldInfo.FieldType == typeof(System.DateTime))
                    {
                        property.SetColumnType("timestamptz");
                    }
                    else if (fieldInfo.FieldType == typeof(System.Guid) && fieldInfo.Name == "id")
                    {
                        //property.SetDefaultValueSql("next_uuid()");
                    }
                }
                if (property.GetColumnType() == "jsonb")
                {
                    //property.Relational().DefaultValueSql = "'{}'";
                }
            }
        }
        return builder;
    }
    public static ModelBuilder StringSize(this ModelBuilder builder)
    {
        // For Npgsql
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                // max char length in sqlserver
                if (property.GetMaxLength() == 67108864)
                {
                    // max char length value in postgresql
                    property.SetMaxLength(10485760);
                }
            }
        }
        return builder;
    }
    /// <summary>
    /// Init PostgreSQL extension
    /// https://github.com/npgsql/Npgsql.EntityFrameworkCore.PostgreSQL/issues/746
	/// Add options.UseNpgsql(o => o.UseNetTopologySuite());
    /// </summary>
    /// <param name="builder"></param>
    public static ModelBuilder InitPostgreSQLExtension(this ModelBuilder builder)
    {
        //builder.ForNpgsqlUseIdentityColumns();
        //builder.UseSerialColumns();
        builder.UseIdentityColumns();
        builder.HasPostgresExtension("timescaledb");
        builder.HasPostgresExtension("uuid-ossp");
        builder.HasPostgresExtension("postgis");
        //builder.HasPostgresExtension("hstore");  // Require super user
        //builder.SnakeCase();
        builder.PostgreSQLDataType();
        builder.StringSize();
        return builder;
    }
}