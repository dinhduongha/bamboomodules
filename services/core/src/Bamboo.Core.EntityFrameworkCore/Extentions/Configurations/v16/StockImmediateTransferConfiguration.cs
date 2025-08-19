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
        public static void ConfigureStockImmediateTransfer(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockImmediateTransfer>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_immediate_transfer_pkey");

            entity.ToTable("stock_immediate_transfer");

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
            entity.Property(e => e.ShowTransfers).HasColumnName("show_transfers");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.StockImmediateTransferCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_immediate_transfer_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.StockImmediateTransferWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_immediate_transfer_write_uid_fkey");

            // entity.HasMany(d => d.StockPicking).WithMany(p => p.StockImmediateTransfer)
            entity.HasMany(d => d.StockPicking).WithMany(p => p.StockImmediateTransfer)
                .UsingEntity<Dictionary<string, object>>(
                    "StockPickingTransferRel",
                    r => r.HasOne<StockPicking>().WithMany()
                        .HasForeignKey("StockPickingId")
                        .HasConstraintName("stock_picking_transfer_rel_stock_picking_id_fkey"),
                    l => l.HasOne<StockImmediateTransfer>().WithMany()
                        .HasForeignKey("StockImmediateTransferId")
                        .HasConstraintName("stock_picking_transfer_rel_stock_immediate_transfer_id_fkey"),
                    j =>
                    {
                        j.HasKey("StockImmediateTransferId", "StockPickingId").HasName("stock_picking_transfer_rel_pkey");
                        j.ToTable("stock_picking_transfer_rel");
                        j.HasIndex(new[] { "StockPickingId", "StockImmediateTransferId" }, "stock_picking_transfer_rel_stock_picking_id_stock_immediate_idx");
                        j.IndexerProperty<Guid>("StockImmediateTransferId").HasColumnName("stock_immediate_transfer_id");
                        j.IndexerProperty<Guid>("StockPickingId").HasColumnName("stock_picking_id");
                    });
            });
        }
    }
}