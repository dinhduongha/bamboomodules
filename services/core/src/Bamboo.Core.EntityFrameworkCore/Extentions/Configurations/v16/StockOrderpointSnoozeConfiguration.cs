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
        public static void ConfigureStockOrderpointSnooze(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockOrderpointSnooze>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_orderpoint_snooze_pkey");

            entity.ToTable("stock_orderpoint_snooze");

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
            entity.Property(e => e.PredefinedDate).HasColumnName("predefined_date");
            entity.Property(e => e.SnoozedUntil).HasColumnName("snoozed_until");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.StockOrderpointSnoozeCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_orderpoint_snooze_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.StockOrderpointSnoozeWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_orderpoint_snooze_write_uid_fkey");

            // entity.HasMany(d => d.StockWarehouseOrderpoint).WithMany(p => p.StockOrderpointSnooze)
            entity.HasMany(d => d.StockWarehouseOrderpoint).WithMany(p => p.StockOrderpointSnooze)
                .UsingEntity<Dictionary<string, object>>(
                    "StockOrderpointSnoozeStockWarehouseOrderpointRel",
                    r => r.HasOne<StockWarehouseOrderpoint>().WithMany()
                        .HasForeignKey("StockWarehouseOrderpointId")
                        .HasConstraintName("stock_orderpoint_snooze_stock_stock_warehouse_orderpoint_i_fkey"),
                    l => l.HasOne<StockOrderpointSnooze>().WithMany()
                        .HasForeignKey("StockOrderpointSnoozeId")
                        .HasConstraintName("stock_orderpoint_snooze_stock_w_stock_orderpoint_snooze_id_fkey"),
                    j =>
                    {
                        j.HasKey("StockOrderpointSnoozeId", "StockWarehouseOrderpointId").HasName("stock_orderpoint_snooze_stock_warehouse_orderpoint_rel_pkey");
                        j.ToTable("stock_orderpoint_snooze_stock_warehouse_orderpoint_rel");
                        j.HasIndex(new[] { "StockWarehouseOrderpointId", "StockOrderpointSnoozeId" }, "stock_orderpoint_snooze_stock_stock_warehouse_orderpoint_id_idx");
                        j.IndexerProperty<Guid>("StockOrderpointSnoozeId").HasColumnName("stock_orderpoint_snooze_id");
                        j.IndexerProperty<Guid>("StockWarehouseOrderpointId").HasColumnName("stock_warehouse_orderpoint_id");
                    });
            });
        }
    }
}