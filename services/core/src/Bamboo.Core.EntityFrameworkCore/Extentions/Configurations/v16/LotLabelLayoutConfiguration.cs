using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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
                        entity.Property(e => e.LabelQuantity).HasColumnName("label_quantity");
                        entity.Property(e => e.PrintFormat).HasColumnName("print_format");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.LotLabelLayoutCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("lot_label_layout_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("lot_label_layout_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.LotLabelLayoutWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("lot_label_layout_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("lot_label_layout_write_uid_fkey");

                        // entity.HasMany(d => d.StockMoveLine).WithMany(p => p.LotLabelLayout)
                        entity.HasMany(d => d.StockMoveLine).WithMany(p => p.LotLabelLayout)
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

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}