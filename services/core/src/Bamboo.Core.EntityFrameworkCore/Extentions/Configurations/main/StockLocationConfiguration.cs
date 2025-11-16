using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureStockLocation(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockLocation>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_location_pkey");

                        entity.ToTable("stock_location");

                        entity.HasIndex(e => e.TenantId, "stock_location__company_id_index");

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.LocationId, "stock_location__location_id_index");

                        entity.HasIndex(e => e.ParentPath, "stock_location__parent_path_index");

                        entity.HasIndex(e => e.StorageCategoryId, "stock_location__storage_category_id_index").HasFilter("(storage_category_id IS NOT NULL)");

                        entity.HasIndex(e => e.Usage, "stock_location__usage_index");

                        entity.HasIndex(e => new { e.Barcode, e.TenantId }, "stock_location_barcode_company_uniq").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.Barcode).HasColumnName("barcode");

                        entity.Property(e => e.CompleteName).HasColumnName("complete_name");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CyclicInventoryFrequency).HasColumnName("cyclic_inventory_frequency");
                        entity.Property(e => e.LastInventoryDate).HasColumnName("last_inventory_date");
                        entity.Property(e => e.LocationId).HasColumnName("location_id");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.NextInventoryDate).HasColumnName("next_inventory_date");
                        entity.Property(e => e.ParentPath).HasColumnName("parent_path");
                        entity.Property(e => e.RemovalStrategyId).HasColumnName("removal_strategy_id");
                        entity.Property(e => e.ReplenishLocation).HasColumnName("replenish_location");
                        entity.Property(e => e.StorageCategoryId).HasColumnName("storage_category_id");
                        entity.Property(e => e.Usage).HasColumnName("usage");
                        entity.Property(e => e.ValuationAccountId).HasColumnName("valuation_account_id");
                        entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.StockLocation) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_location_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_location_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.StockLocationCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_location_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_location_create_uid_fkey");

                        entity.HasOne(d => d.Location).WithMany(p => p.InverseLocation)
                            .HasForeignKey(d => d.LocationId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_location_location_id_fkey");

                        entity.HasOne(d => d.RemovalStrategy).WithMany(p => p.StockLocation)
                            .HasForeignKey(d => d.RemovalStrategyId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_location_removal_strategy_id_fkey");

                        entity.HasOne(d => d.StorageCategory).WithMany(p => p.StockLocation)
                            .HasForeignKey(d => d.StorageCategoryId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_location_storage_category_id_fkey");

                        // entity.HasOne(d => d.ValuationAccount).WithMany(p => p.StockLocation) .HasForeignKey(d => d.ValuationAccountId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_location_valuation_account_id_fkey");
                        entity.HasOne(d => d.ValuationAccount).WithMany()
                            .HasForeignKey(d => d.ValuationAccountId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_location_valuation_account_id_fkey");

                        entity.HasOne(d => d.Warehouse).WithMany(p => p.StockLocation)
                            .HasForeignKey(d => d.WarehouseId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_location_warehouse_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.StockLocationWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_location_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_location_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}