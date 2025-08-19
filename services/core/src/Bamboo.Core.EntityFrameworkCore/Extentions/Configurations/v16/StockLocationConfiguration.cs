using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;
// Cần thêm using đến namespace chứa entity của bạn ở đây
// Ví dụ: using YourProject.Entities;

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

            entity.HasIndex(e => e.Usage, "stock_location__usage_index");

            entity.HasIndex(e => new { e.Barcode, e.TenantId }, "stock_location_barcode_company_uniq").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Barcode).HasColumnName("barcode");
            entity.Property(e => e.Comment).HasColumnName("comment");

            entity.Property(e => e.CompleteName).HasColumnName("complete_name");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.CyclicInventoryFrequency).HasColumnName("cyclic_inventory_frequency");
            entity.Property(e => e.IsADock).HasColumnName("is_a_dock");
            entity.Property(e => e.IsSubcontractingLocation).HasColumnName("is_subcontracting_location");
            entity.Property(e => e.LastInventoryDate).HasColumnName("last_inventory_date");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.NextInventoryDate).HasColumnName("next_inventory_date");
            entity.Property(e => e.ParentPath).HasColumnName("parent_path");
            entity.Property(e => e.Posx).HasColumnName("posx");
            entity.Property(e => e.Posy).HasColumnName("posy");
            entity.Property(e => e.Posz).HasColumnName("posz");
            entity.Property(e => e.RemovalStrategyId).HasColumnName("removal_strategy_id");
            entity.Property(e => e.ReplenishLocation).HasColumnName("replenish_location");
            entity.Property(e => e.ReturnLocation).HasColumnName("return_location");
            entity.Property(e => e.ScrapLocation).HasColumnName("scrap_location");
            entity.Property(e => e.StorageCategoryId).HasColumnName("storage_category_id");
            entity.Property(e => e.Usage).HasColumnName("usage");
            entity.Property(e => e.ValuationInAccountId).HasColumnName("valuation_in_account_id");
            entity.Property(e => e.ValuationOutAccountId).HasColumnName("valuation_out_account_id");
            entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.Company).WithMany(p => p.StockLocation)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_location_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.StockLocationCreateU)
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

            //entity.HasOne(d => d.ValuationInAccount).WithMany(p => p.StockLocationValuationInAccount)
            entity.HasOne(d => d.ValuationInAccount).WithMany()
                .HasForeignKey(d => d.ValuationInAccountId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_location_valuation_in_account_id_fkey");

            //entity.HasOne(d => d.ValuationOutAccount).WithMany(p => p.StockLocationValuationOutAccount)
            entity.HasOne(d => d.ValuationOutAccount).WithMany()
                .HasForeignKey(d => d.ValuationOutAccountId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_location_valuation_out_account_id_fkey");

            entity.HasOne(d => d.Warehouse).WithMany(p => p.StockLocation)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_location_warehouse_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.StockLocationWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_location_write_uid_fkey");
            });
        }
    }
}
