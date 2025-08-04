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
        public static void ConfigureLotLabelLayout(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LotLabelLayout>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("lot_label_layout_pkey");

                entity.ToTable("lot_label_layout");

                entity.HasIndex(e => e.TenantId, "lot_label_layout_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.LabelQuantity).HasColumnName("label_quantity");
                entity.Property(e => e.PrintFormat).HasColumnName("print_format");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("lot_label_layout_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("lot_label_layout_write_uid_fkey");

                //entity.HasMany(d => d.StockPickings).WithMany(p => p.LotLabelLayouts)
                entity.HasMany<StockPicking>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "LotLabelLayoutStockPickingRel",
                        r => r.HasOne<StockPicking>().WithMany()
                            .HasForeignKey("StockPickingId")
                            .HasConstraintName("lot_label_layout_stock_picking_rel_stock_picking_id_fkey"),
                        l => l.HasOne<LotLabelLayout>().WithMany()
                            .HasForeignKey("LotLabelLayoutId")
                            .HasConstraintName("lot_label_layout_stock_picking_rel_lot_label_layout_id_fkey"),
                        j =>
                        {
                            j.HasKey("LotLabelLayoutId", "StockPickingId").HasName("lot_label_layout_stock_picking_rel_pkey");
                            j.ToTable("lot_label_layout_stock_picking_rel");
                            j.HasIndex(new[] { "StockPickingId", "LotLabelLayoutId" }, "lot_label_layout_stock_pickin_stock_picking_id_lot_label_la_idx");
                        });

                entity.HasMany(d => d.StockMoveLines).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "LotLabelLayoutStockMoveLineRel",
                        r => r.HasOne<StockMoveLine>().WithMany()
                            .HasForeignKey("StockMoveLineId")
                            .HasConstraintName("lot_label_layout_stock_move_line_rel_stock_move_line_id_fkey"),
                        l => l.HasOne<LotLabelLayout>().WithMany()
                            .HasForeignKey("LotLabelLayoutId")
                            .HasConstraintName("lot_label_layout_stock_move_line_rel_lot_label_layout_id_fkey"),
                        j =>
                        {
                            j.HasKey("LotLabelLayoutId", "StockMoveLineId").HasName("lot_label_layout_stock_move_line_rel_pkey");
                            j.ToTable("lot_label_layout_stock_move_line_rel");
                            j.HasIndex(new[] { "StockMoveLineId", "LotLabelLayoutId" }, "lot_label_layout_stock_move_l_stock_move_line_id_lot_label__idx");
                            j.IndexerProperty<Guid>("LotLabelLayoutId").HasColumnName("lot_label_layout_id");
                            j.IndexerProperty<Guid>("StockMoveLineId").HasColumnName("stock_move_line_id");
                        });
            });
        }
    }
}