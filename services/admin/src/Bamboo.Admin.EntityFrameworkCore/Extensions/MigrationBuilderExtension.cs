using System;
using System.Reflection;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Migrations;

using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Metadata;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;

public static class MigrationBuilderExtension
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/operations
    /// https://github.com/schinckel/ulid-postgres
    /// https://github.com/tvondra/sequential-uuids
    /// https://stackoverflow.com/questions/27284910/create-big-integer-from-the-big-end-of-a-uuid-in-postgresql
    /// https://github.com/iCyberon/pg_ulid
    /// https://github.com/dinhduongha/next-uuid
    /// EXPLAIN ANALYZE
    /// SELECT next_uuid() FROM generate_series(1,100000);
    /// </summary>
    /// <param name="migrationBuilder"></param>
    public static string NextUUID = @"CREATE OR REPLACE FUNCTION next_uuid(OUT result uuid) AS $$
                    DECLARE
                        now_micros bigint;
                        second_rand bigint;
                        hex_value text;
                        shard_id int:=1;
                    BEGIN
                        -- Can use clock_timestamp() / statement_timestamp() / transaction_timestamp()/ current_timestamp
                        select (extract(epoch from current_timestamp)*1000000)::BIGINT INTO now_micros;
                        select ((random() * 10^18)::BIGINT) INTO second_rand;
                        -- Uncomment below line to ignore sharding.
                        -- select ((random() * 10^6)::INT) INTO shard_id;
	                    -- [milliseconds(6 bytes) + microseconds(12 bits) + shard(4 bits) + random(8 bytes)]
                        hex_value := LPAD(TO_HEX(now_micros/1000), 12, '0')||LPAD(TO_HEX(now_micros%1000), 3, '0')||LPAD(TO_HEX(shard_id), 1, '0')||LPAD(TO_HEX(second_rand), 16, '0');
                        result := CAST(hex_value AS UUID);
	                    -- TEST PERFOMANCE
	                    -- EXPLAIN ANALYZE
                        -- SELECT next_uuid() FROM generate_series(1,100000);
                    END;
                    $$ LANGUAGE PLPGSQL;
            ";
    public static MigrationBuilder CreateNewUUIDSP(this MigrationBuilder migrationBuilder)
    {
        switch (migrationBuilder.ActiveProvider)
        {
            case "Npgsql.EntityFrameworkCore.PostgreSQL":
                {
                    try
                    {
                        migrationBuilder.Sql(NextUUID);
                    }
                    catch (Exception)
                    { 
                    }
                }
                break;
            case "Microsoft.EntityFrameworkCore.SqlServer":
                {
                    return migrationBuilder;
                }
        }
        return migrationBuilder;
    }
    public static MigrationBuilder CreateTimescaleDB(this MigrationBuilder migrationBuilder, string table, string time)
    {
        switch (migrationBuilder.ActiveProvider)
        {
            case "Npgsql.EntityFrameworkCore.PostgreSQL":
                {
                    migrationBuilder.Sql($"SELECT create_hypertable('{table}', '{time}');");
                }
                break;
            case "Microsoft.EntityFrameworkCore.SqlServer":
                {
                    return migrationBuilder;
                }
        }
        return migrationBuilder;
    }

    public static MigrationBuilder CreateTimescaleDB(this MigrationBuilder migrationBuilder)
    {
        return migrationBuilder;
    }
}

//public class MySqlServerMigrationsSqlGenerator : SqlServerMigrationsSqlGenerator
//{
//    public MySqlServerMigrationsSqlGenerator(
//        MigrationsSqlGeneratorDependencies dependencies,
//        IRelationalAnnotationProvider migrationsAnnotations)
//        : base(dependencies, migrationsAnnotations)
//    {
//    }

//    protected override void Generate(
//        MigrationOperation operation,
//        IModel model,
//        MigrationCommandListBuilder builder)
//    {
//        if (operation is AlterDatabaseOperation alterDatabaseOperation)
//        {
//        }
//        else
//        {
//            base.Generate(operation, model, builder);
//        }
//    }
//}

public class MyPostgresMigrationsSqlGenerator : NpgsqlMigrationsSqlGenerator
{
    public MyPostgresMigrationsSqlGenerator(
        MigrationsSqlGeneratorDependencies dependencies,
        INpgsqlSingletonOptions npgsqlOptions
        )
        : base(dependencies,  npgsqlOptions)
    {
    }

    /// https://clearmeasure.com/creating-stored-procs-in-ef-migrations/
    protected override void Generate(
        MigrationOperation operation,
        IModel model,
        MigrationCommandListBuilder builder)
    {
        if (operation is AlterDatabaseOperation alterDatabaseOperation)
        {
            builder.Append($"{MigrationBuilderExtension.NextUUID}").EndCommand();
            var ext = @"
                    CREATE EXTENSION if not exists timescaledb;
                    CREATE EXTENSION if not exists postgis;
                    CREATE EXTENSION if not exists ""uuid-ossp"";
                    ";
            builder.Append($"{ext}").EndCommand();
            //builder.Append($"CREATE EXTENSION if not exists timescaledb;").EndCommand();
            //builder.Append($"CREATE EXTENSION if not exists postgis;").EndCommand();
            //builder.Append($"CREATE EXTENSION if not exists \"uuid-ossp\";").EndCommand();
            var assembly = Assembly.GetExecutingAssembly();
            var resourceNames =
                        assembly.GetManifestResourceNames().
                        Where(str => str.EndsWith(".sql"));
            foreach (string resourceName in resourceNames)
            {
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                using (StreamReader reader = new StreamReader(stream))
                {
                    string sql = reader.ReadToEnd();
                    builder.Append($"{sql}").EndCommand();
                }
            }
        }
        base.Generate(operation, model, builder);            
    }
}