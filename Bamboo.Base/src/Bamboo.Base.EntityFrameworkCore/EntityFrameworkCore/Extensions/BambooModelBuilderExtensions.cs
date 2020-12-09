using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;


namespace Bamboo.Base.EntityFrameworkCore
{
    public static partial class BaseModelBuilderExtensions
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
                    property.SetColumnName(property.GetColumnName().ToSnakeCase());
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
                    index.SetName(index.GetName().ToSnakeCase());
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
                        int changed = 0;

                        if (fieldInfo.FieldType == typeof(System.Nullable<System.DateTime>))
                        {
                            changed = 1;
                            property.SetColumnType("timestamptz");
                        }
                        else if (fieldInfo.FieldType == typeof(System.DateTime))
                        {
                            changed = 2;
                            property.SetColumnType("timestamptz");
                        }
                        else if (fieldInfo.FieldType == typeof(System.Guid))
                        {
                            if (property.GetColumnName().ToLower() == "id")
                            {
                                changed = 3;
                                property.SetDefaultValueSql("next_uuid()");
                            }
                            if (property.GetColumnName().ToLower() == "Id")
                            {
                                changed = 4;
                                property.SetDefaultValueSql("next_uuid()");
                            }
                        }
                        else if (fieldInfo.FieldType == typeof(Volo.Abp.Data.IHasExtraProperties))
                        {
                            //if (property.GetColumnName() == "ExtraProperties")
                            //{
                            //    changed = 5;
                            //    property.SetColumnType("jsonb");
                            //}
                        }    
                        //Console.WriteLine($"Change: {changed} - {entity.GetTableName()} - {fieldInfo.Name} - {fieldInfo.FieldType}");

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
        /// </summary>
        /// <param name="builder"></param>
        public static ModelBuilder InitExtension(this ModelBuilder builder)
        {
            //builder.ForNpgsqlUseIdentityColumns();
            //builder.UseIdentityColumns();
            //builder.HasPostgresExtension("postgis");
            //builder.HasPostgresExtension("timescaledb");
            //builder.HasPostgresExtension("uuid-ossp");
            //builder.HasPostgresExtension("hstore");  // Require super user
            return builder;
        }
    }
}