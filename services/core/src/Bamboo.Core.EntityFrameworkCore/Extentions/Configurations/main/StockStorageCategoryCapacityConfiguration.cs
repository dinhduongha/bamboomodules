using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureStockStorageCategoryCapacity(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockStorageCategoryCapacity>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_storage_category_capacity_pkey");

                        entity.ToTable("stock_storage_category_capacity");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.PackageTypeId, "stock_storage_category_capacity__package_type_id_index").HasFilter("(package_type_id IS NOT NULL)");

                        entity.HasIndex(e => e.ProductId, "stock_storage_category_capacity__product_id_index").HasFilter("(product_id IS NOT NULL)");

                        entity.HasIndex(e => e.StorageCategoryId, "stock_storage_category_capacity__storage_category_id_index");

                        entity.HasIndex(e => new { e.PackageTypeId, e.StorageCategoryId }, "stock_storage_category_capacity_unique_package_type").IsUnique();

                        entity.HasIndex(e => new { e.ProductId, e.StorageCategoryId }, "stock_storage_category_capacity_unique_product").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.PackageTypeId).HasColumnName("package_type_id");
                        entity.Property(e => e.ProductId).HasColumnName("product_id");
                        entity.Property(e => e.Quantity).HasColumnName("quantity");
                        entity.Property(e => e.StorageCategoryId).HasColumnName("storage_category_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.StockStorageCategoryCapacityCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_storage_category_capacity_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_storage_category_capacity_create_uid_fkey");

                        entity.HasOne(d => d.PackageType).WithMany(p => p.StockStorageCategoryCapacity)
                            .HasForeignKey(d => d.PackageTypeId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("stock_storage_category_capacity_package_type_id_fkey");

                        // entity.HasOne(d => d.Product).WithMany(p => p.StockStorageCategoryCapacity) .HasForeignKey(d => d.ProductId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("stock_storage_category_capacity_product_id_fkey");
                        entity.HasOne(d => d.Product).WithMany()
                            .HasForeignKey(d => d.ProductId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("stock_storage_category_capacity_product_id_fkey");

                        entity.HasOne(d => d.StorageCategory).WithMany(p => p.StockStorageCategoryCapacity)
                            .HasForeignKey(d => d.StorageCategoryId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("stock_storage_category_capacity_storage_category_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.StockStorageCategoryCapacityWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_storage_category_capacity_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_storage_category_capacity_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}