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
        public static void ConfigureStockInventoryAdjustmentName(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockInventoryAdjustmentName>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_inventory_adjustment_name_pkey");

            entity.ToTable("stock_inventory_adjustment_name");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.InventoryAdjustmentName).HasColumnName("inventory_adjustment_name");
            entity.Property(e => e.ShowInfo).HasColumnName("show_info");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.StockInventoryAdjustmentNameCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_inventory_adjustment_name_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.StockInventoryAdjustmentNameWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_inventory_adjustment_name_write_uid_fkey");

            // entity.HasMany(d => d.StockQuant).WithMany(p => p.StockInventoryAdjustmentName)
            entity.HasMany(d => d.StockQuant).WithMany(p => p.StockInventoryAdjustmentName)
                .UsingEntity<Dictionary<string, object>>(
                    "StockInventoryAdjustmentNameStockQuantRel",
                    r => r.HasOne<StockQuant>().WithMany()
                        .HasForeignKey("StockQuantId")
                        .HasConstraintName("stock_inventory_adjustment_name_stock_quant_stock_quant_id_fkey"),
                    l => l.HasOne<StockInventoryAdjustmentName>().WithMany()
                        .HasForeignKey("StockInventoryAdjustmentNameId")
                        .HasConstraintName("stock_inventory_adjustment_na_stock_inventory_adjustment_n_fkey"),
                    j =>
                    {
                        j.HasKey("StockInventoryAdjustmentNameId", "StockQuantId").HasName("stock_inventory_adjustment_name_stock_quant_rel_pkey");
                        j.ToTable("stock_inventory_adjustment_name_stock_quant_rel");
                        j.HasIndex(new[] { "StockQuantId", "StockInventoryAdjustmentNameId" }, "stock_inventory_adjustment_na_stock_quant_id_stock_inventor_idx");
                        j.IndexerProperty<Guid>("StockInventoryAdjustmentNameId").HasColumnName("stock_inventory_adjustment_name_id");
                        j.IndexerProperty<Guid>("StockQuantId").HasColumnName("stock_quant_id");
                    });
            });
        }
    }
}