using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
// TODO: Hãy chắc chắn rằng bạn đã thêm using cho namespace chứa Models của mình ở đây
// Ví dụ: using YourProject.Models;
using Bamboo.Core.Models;
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

                entity.HasIndex(e => e.TenantId, "stock_immediate_transfer_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.ShowTransfers).HasColumnName("show_transfers");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_immediate_transfer_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_immediate_transfer_write_uid_fkey");

                //entity.HasMany(d => d.StockPickings).WithMany(p => p.StockImmediateTransfers)
                entity.HasMany<StockPicking>().WithMany()
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
                        });
            });
        }
    }
}