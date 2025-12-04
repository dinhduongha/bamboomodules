using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;
using Volo.Abp.EntityFrameworkCore.Modeling;

using Bamboo.Admin;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public static class DbContextModelCreatingExtensions
{
    /*
	    builder.InitPostgreSQLExtension();

        base.OnModelCreating(builder);

        builder.ConfigureBamboo();
	*/

    public static void ConfigureBamboo(this ModelBuilder builder)
    {
        builder.HasPostgresExtension("pg_trgm");
        //modelBuilder.HasPostgresExtension("btree_gist");

        // Áp dụng global cho tất cả FullAudited entities (nếu dùng ABP 8.x+)
        //modelBuilder.Entity<FullAuditedAggregateRoot<Guid>>(b => b.Property(e => e.ExtraProperties).IsRequired(false));

        // Lấy tất cả các type kế thừa từ FullAuditedAggregateRoot<Guid>
        // var entityTypes = modelBuilder.Model.GetEntityTypes()
        // .Where(t => typeof(FullAuditedAggregateRoot<Guid>).IsAssignableFrom(t.ClrType) && t.ClrType != typeof(FullAuditedAggregateRoot<Guid>));

        // Lấy tất cả các entity implement IHasExtraProperties
        var entityTypeExtras = builder.Model.GetEntityTypes()
            .Where(t => typeof(IHasExtraProperties).IsAssignableFrom(t.ClrType) && !t.ClrType.IsAbstract);

        foreach (var entityType in entityTypeExtras)
        {
            // Cấu hình ExtraProperties nullable cho entity
            builder.Entity(entityType.ClrType, b =>
            {
                b.Property(nameof(IHasExtraProperties.ExtraProperties)).IsRequired(false);
            });
        }

        // var entityTypeConcurrencyStamps = modelBuilder.Model.GetEntityTypes()
        //     .Where(t => typeof(IHasConcurrencyStamp).IsAssignableFrom(t.ClrType) && !t.ClrType.IsAbstract);

        // foreach (var entityType in entityTypeConcurrencyStamps)
        // {
        //     // Cấu hình ExtraProperties nullable cho entity
        //     modelBuilder.Entity(entityType.ClrType, b =>
        //     {
        //         b.Property(nameof(IHasConcurrencyStamp.ConcurrencyStamp))
        //             .IsRequired(false)
        //             .HasDefaultValueSql("uuidv7()::text"); ;
        //     });
        // }

        var entityTypes = builder.Model.GetEntityTypes()
            // Lọc ra các entity class kế thừa IEntity và không phải abstract
            .Where(t => typeof(IEntity).IsAssignableFrom(t.ClrType) && !t.ClrType.IsAbstract);

        foreach (var entityType in entityTypes)
        {
            // Lấy đối tượng PropertyInfo của thuộc tính "Id"
            var idProperty = entityType.ClrType.GetProperty("Id");

            // Chỉ cấu hình nếu thuộc tính "Id" tồn tại trên Entity và có kiểu Guid
            if (idProperty != null && idProperty.PropertyType == typeof(Guid))
            {
                builder.Entity(entityType.ClrType, b =>
                {
                    b.Property("Id") // Dùng tên chuỗi "Id" hoặc nameof(IEntity.Id)
                        .HasDefaultValueSql("uuidv7()");
                });
            }
        }

        Check.NotNull(builder, nameof(builder));

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(BambooConsts.DbTablePrefix + "YourEntities", BambooConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});

        // builder.Entity<TenantOwner>(b =>
        // {
        //     b.ToTable("AbpTenants")
        //      .HasIndex(b => b.OwnerId);
        //     b.ConfigureByConvention(); //auto configure for the base class props
        //     //...
        // });
        // builder.Entity<UserBrand>(b =>
        // {
        //     b.ToTable("AbpUsers").HasIndex(b => b.BrandId);
        //     b.ConfigureByConvention(); //auto configure for the base class props
        //     //...
        // });

        // builder.Entity<RolesExtra>(b =>
        // {
        //     b.ToTable("AbpRoles").HasIndex(b => b.BrandId);
        //     b.ConfigureByConvention(); //auto configure for the base class props
        //     //...
        // });

        // builder.Entity<UserLoginExtra>(b =>
        // {
        //     b.ToTable("AbpUserLogins");
        //     b.ConfigureByConvention(); //auto configure for the base class props
        //     //...
        // });

        //builder.Entity<OpenIddictApplicationExtra>(b =>
        //{
        //    b.ToTable("OpenIddictApplications").HasIndex(b => b.TenantId);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
        builder.Entity<TenantMember>(b =>
        {
            b.HasIndex(b => b.Id).IsUnique(true);
            b.HasIndex(b => b.TenantId);
            b.HasIndex(b => b.UserId);
            b.HasIndex(b => new { TenantId = b.TenantId, UserId = b.UserId }).IsUnique(true);
            b.HasKey(e => e.Id);
            b.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

            b.Property(x => x.Roles)
             .HasConversion(
                 // Khi lưu vào DB: Convert List -> JSON String
                 v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),

                 // Khi đọc từ DB: Convert JSON String -> List
                 v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null) ?? new List<string>()
             );

            // Để EF Core so sánh được sự thay đổi của List (Value Comparer)
            // Phần này hơi nâng cao, cần thiết để EF biết khi nào bạn Add item vào list để update DB
            // Nếu không có, EF có thể không nhận ra sự thay đổi.
            var valueComparer = new ValueComparer<List<string>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList());

            b.Property(x => x.Roles).Metadata.SetValueComparer(valueComparer);
        });

        builder.Entity<TenantRegistration>(b =>
        {
            b.HasIndex(b => b.Id).IsUnique(true);
            b.HasIndex(b => b.UserId);
            b.HasIndex(b => b.Name);
            b.HasKey(e => e.Id);

            b.Property(e => e.Id)
                .HasDefaultValueSql("uuidv7()")
                .HasColumnName("id");

        });
        builder.UseIdentityColumns();
        builder.UseSerialColumns();
        builder.StringSize();
        builder.PostgreSQLDataType();
        //builder.SnakeCase();
        // Change to lower case:
        // https://github.com/abpframework/abp/issues/2131
    }
}