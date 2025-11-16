using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureStockMoveLine(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockMoveLine>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_move_line_pkey");

                        entity.ToTable("stock_move_line");

                        entity.HasIndex(e => e.TenantId, "stock_move_line__company_id_index");

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.LocationDestId, "stock_move_line__location_dest_id_index");

                        entity.HasIndex(e => e.LocationId, "stock_move_line__location_id_index");

                        entity.HasIndex(e => e.MoveId, "stock_move_line__move_id_index");

                        entity.HasIndex(e => e.OwnerId, "stock_move_line__owner_id_index").HasFilter("(owner_id IS NOT NULL)");

                        entity.HasIndex(e => e.PackageHistoryId, "stock_move_line__package_history_id_index").HasFilter("(package_history_id IS NOT NULL)");

                        entity.HasIndex(e => e.PickingId, "stock_move_line__picking_id_index");

                        entity.HasIndex(e => e.ProductId, "stock_move_line__product_id_index");

                        entity.HasIndex(e => e.WorkorderId, "stock_move_line__workorder_id_index").HasFilter("(workorder_id IS NOT NULL)");

                        entity.HasIndex(e => new { e.Id, e.TenantId, e.ProductId, e.LotId, e.LocationId, e.OwnerId, e.PackageId }, "stock_move_line_free_reservation_index").HasFilter("(((state IS NULL) OR (state <> ALL (ARRAY[('cancel'::character varying)::text, ('done'::character varying)::text]))) AND (quantity_product_uom > (0)::numeric) AND (picked IS NOT TRUE))");

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
                        entity.Property(e => e.Date)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date");
                        entity.Property(e => e.ExpirationDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("expiration_date");
                        entity.Property(e => e.IsEntirePack).HasColumnName("is_entire_pack");
                        entity.Property(e => e.LocationDestId).HasColumnName("location_dest_id");
                        entity.Property(e => e.LocationId).HasColumnName("location_id");
                        entity.Property(e => e.LotId).HasColumnName("lot_id");
                        entity.Property(e => e.LotName).HasColumnName("lot_name");
                        entity.Property(e => e.MoveId).HasColumnName("move_id");
                        entity.Property(e => e.OwnerId).HasColumnName("owner_id");
                        entity.Property(e => e.PackageHistoryId).HasColumnName("package_history_id");
                        entity.Property(e => e.PackageId).HasColumnName("package_id");
                        entity.Property(e => e.Picked).HasColumnName("picked");
                        entity.Property(e => e.PickingId).HasColumnName("picking_id");
                        entity.Property(e => e.ProductId).HasColumnName("product_id");
                        entity.Property(e => e.ProductUomId).HasColumnName("product_uom_id");
                        entity.Property(e => e.ProductionId).HasColumnName("production_id");
                        entity.Property(e => e.Quantity).HasColumnName("quantity");
                        entity.Property(e => e.QuantityProductUom).HasColumnName("quantity_product_uom");
                        entity.Property(e => e.RemovalDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("removal_date");
                        entity.Property(e => e.ResultPackageId).HasColumnName("result_package_id");
                        entity.Property(e => e.State).HasColumnName("state");
                        entity.Property(e => e.WorkorderId).HasColumnName("workorder_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.StockMoveLine) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("stock_move_line_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("stock_move_line_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.StockMoveLineCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_move_line_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_move_line_create_uid_fkey");

                        entity.HasOne(d => d.LocationDest).WithMany(p => p.StockMoveLineLocationDest)
                            .HasForeignKey(d => d.LocationDestId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("stock_move_line_location_dest_id_fkey");

                        entity.HasOne(d => d.Location).WithMany(p => p.StockMoveLineLocation)
                            .HasForeignKey(d => d.LocationId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("stock_move_line_location_id_fkey");

                        entity.HasOne(d => d.Lot).WithMany(p => p.StockMoveLine)
                            .HasForeignKey(d => d.LotId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_move_line_lot_id_fkey");

                        entity.HasOne(d => d.Move).WithMany(p => p.StockMoveLine)
                            .HasForeignKey(d => d.MoveId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_move_line_move_id_fkey");

                        // entity.HasOne(d => d.Owner).WithMany(p => p.StockMoveLine) .HasForeignKey(d => d.OwnerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_move_line_owner_id_fkey");
                        entity.HasOne(d => d.Owner).WithMany()
                            .HasForeignKey(d => d.OwnerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_move_line_owner_id_fkey");

                        entity.HasOne(d => d.PackageHistory).WithMany(p => p.StockMoveLine)
                            .HasForeignKey(d => d.PackageHistoryId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_move_line_package_history_id_fkey");

                        entity.HasOne(d => d.Package).WithMany(p => p.StockMoveLinePackage)
                            .HasForeignKey(d => d.PackageId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("stock_move_line_package_id_fkey");

                        entity.HasOne(d => d.Picking).WithMany(p => p.StockMoveLine)
                            .HasForeignKey(d => d.PickingId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_move_line_picking_id_fkey");

                        // entity.HasOne(d => d.Product).WithMany(p => p.StockMoveLine) .HasForeignKey(d => d.ProductId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("stock_move_line_product_id_fkey");
                        entity.HasOne(d => d.Product).WithMany()
                            .HasForeignKey(d => d.ProductId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("stock_move_line_product_id_fkey");

                        // entity.HasOne(d => d.ProductUom).WithMany(p => p.StockMoveLine) .HasForeignKey(d => d.ProductUomId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("stock_move_line_product_uom_id_fkey");
                        entity.HasOne(d => d.ProductUom).WithMany()
                            .HasForeignKey(d => d.ProductUomId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("stock_move_line_product_uom_id_fkey");

                        entity.HasOne(d => d.Production).WithMany(p => p.StockMoveLine)
                            .HasForeignKey(d => d.ProductionId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_move_line_production_id_fkey");

                        entity.HasOne(d => d.ResultPackage).WithMany(p => p.StockMoveLineResultPackage)
                            .HasForeignKey(d => d.ResultPackageId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("stock_move_line_result_package_id_fkey");

                        entity.HasOne(d => d.Workorder).WithMany(p => p.StockMoveLine)
                            .HasForeignKey(d => d.WorkorderId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_move_line_workorder_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.StockMoveLineWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_move_line_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("stock_move_line_write_uid_fkey");

                        // entity.HasMany(d => d.ConsumeLine).WithMany(p => p.ProduceLine)
                        entity.HasMany(d => d.ConsumeLine).WithMany(p => p.ProduceLine)
                            .UsingEntity<Dictionary<string, object>>(
                                "StockMoveLineConsumeRel",
                                r => r.HasOne<StockMoveLine>().WithMany()
                                    .HasForeignKey("ConsumeLineId")
                                    .HasConstraintName("stock_move_line_consume_rel_consume_line_id_fkey"),
                                l => l.HasOne<StockMoveLine>().WithMany()
                                    .HasForeignKey("ProduceLineId")
                                    .HasConstraintName("stock_move_line_consume_rel_produce_line_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ConsumeLineId", "ProduceLineId").HasName("stock_move_line_consume_rel_pkey");
                                    j.ToTable("stock_move_line_consume_rel");
                                    j.HasIndex(new[] { "ProduceLineId", "ConsumeLineId" }, "stock_move_line_consume_rel_produce_line_id_consume_line_id_idx");
                                    j.IndexerProperty<Guid>("ConsumeLineId").HasColumnName("consume_line_id");
                                    j.IndexerProperty<Guid>("ProduceLineId").HasColumnName("produce_line_id");
                                });

                        // entity.HasMany(d => d.ProduceLine).WithMany(p => p.ConsumeLine)
                        entity.HasMany(d => d.ProduceLine).WithMany(p => p.ConsumeLine)
                            .UsingEntity<Dictionary<string, object>>(
                                "StockMoveLineConsumeRel",
                                r => r.HasOne<StockMoveLine>().WithMany()
                                    .HasForeignKey("ProduceLineId")
                                    .HasConstraintName("stock_move_line_consume_rel_produce_line_id_fkey"),
                                l => l.HasOne<StockMoveLine>().WithMany()
                                    .HasForeignKey("ConsumeLineId")
                                    .HasConstraintName("stock_move_line_consume_rel_consume_line_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ConsumeLineId", "ProduceLineId").HasName("stock_move_line_consume_rel_pkey");
                                    j.ToTable("stock_move_line_consume_rel");
                                    j.HasIndex(new[] { "ProduceLineId", "ConsumeLineId" }, "stock_move_line_consume_rel_produce_line_id_consume_line_id_idx");
                                    j.IndexerProperty<Guid>("ConsumeLineId").HasColumnName("consume_line_id");
                                    j.IndexerProperty<Guid>("ProduceLineId").HasColumnName("produce_line_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}