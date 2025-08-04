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
        public static void ConfigureStockMoveLine(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockMoveLine>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("stock_move_line_pkey");

                entity.ToTable("stock_move_line");

                entity.HasIndex(e => e.TenantId, "stock_move_line_company_id_index");

                entity.HasIndex(e => new { e.Id, e.TenantId, e.ProductId, e.LotId, e.LocationId, e.OwnerId, e.PackageId }, "stock_move_line_free_reservation_index").HasFilter("(((state IS NULL) OR (state <> ALL (ARRAY[('cancel'::character varying)::text, ('done'::character varying)::text]))) AND (reserved_qty > (0)::numeric))");

                entity.HasIndex(e => e.MoveId, "stock_move_line_move_id_index");

                entity.HasIndex(e => e.PickingId, "stock_move_line_picking_id_index");

                entity.HasIndex(e => e.ProductId, "stock_move_line_product_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Date)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date");
                entity.Property(e => e.DescriptionPicking).HasColumnName("description_picking");
                entity.Property(e => e.LocationDestId).HasColumnName("location_dest_id");
                entity.Property(e => e.LocationId).HasColumnName("location_id");
                entity.Property(e => e.LotId).HasColumnName("lot_id");
                entity.Property(e => e.LotName).HasColumnName("lot_name");
                entity.Property(e => e.MoveId).HasColumnName("move_id");
                entity.Property(e => e.OwnerId).HasColumnName("owner_id");
                entity.Property(e => e.PackageId).HasColumnName("package_id");
                entity.Property(e => e.PackageLevelId).HasColumnName("package_level_id");
                entity.Property(e => e.PickingId).HasColumnName("picking_id");
                entity.Property(e => e.ProductCategoryName).HasColumnName("product_category_name");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.ProductUomId).HasColumnName("product_uom_id");
                entity.Property(e => e.ProductionId).HasColumnName("production_id");
                entity.Property(e => e.QtyDone).HasColumnName("qty_done");
                entity.Property(e => e.Reference).HasColumnName("reference");
                entity.Property(e => e.ReservedQty).HasColumnName("reserved_qty");
                entity.Property(e => e.ReservedUomQty).HasColumnName("reserved_uom_qty");
                entity.Property(e => e.ResultPackageId).HasColumnName("result_package_id");
                entity.Property(e => e.State).HasColumnName("state");
                entity.Property(e => e.WorkorderId).HasColumnName("workorder_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_move_line_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_line_create_uid_fkey");

                entity.HasOne(d => d.LocationDest).WithMany(p => p.StockMoveLineLocationDests)
                    .HasForeignKey(d => d.LocationDestId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_move_line_location_dest_id_fkey");

                entity.HasOne(d => d.Location).WithMany(p => p.StockMoveLineLocations)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_move_line_location_id_fkey");

                entity.HasOne(d => d.Lot).WithMany(p => p.StockMoveLines)
                    .HasForeignKey(d => d.LotId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_line_lot_id_fkey");

                entity.HasOne(d => d.Move).WithMany(p => p.StockMoveLines)
                    .HasForeignKey(d => d.MoveId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_line_move_id_fkey");

                entity.HasOne(d => d.Owner).WithMany(p => p.StockMoveLines)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_line_owner_id_fkey");

                entity.HasOne(d => d.Package).WithMany(p => p.StockMoveLinePackages)
                    .HasForeignKey(d => d.PackageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_move_line_package_id_fkey");

                entity.HasOne(d => d.PackageLevel).WithMany(p => p.StockMoveLines)
                    .HasForeignKey(d => d.PackageLevelId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_line_package_level_id_fkey");

                entity.HasOne(d => d.Picking).WithMany(p => p.StockMoveLines)
                    .HasForeignKey(d => d.PickingId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_line_picking_id_fkey");

                entity.HasOne(d => d.Product).WithMany(p => p.StockMoveLines)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("stock_move_line_product_id_fkey");

                entity.HasOne(d => d.ProductUom).WithMany(p => p.StockMoveLines)
                    .HasForeignKey(d => d.ProductUomId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_move_line_product_uom_id_fkey");

                entity.HasOne(d => d.Production).WithMany(p => p.StockMoveLines)
                    .HasForeignKey(d => d.ProductionId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_line_production_id_fkey");

                entity.HasOne(d => d.ResultPackage).WithMany(p => p.StockMoveLineResultPackages)
                    .HasForeignKey(d => d.ResultPackageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_move_line_result_package_id_fkey");

                entity.HasOne(d => d.Workorder).WithMany(p => p.StockMoveLines)
                    .HasForeignKey(d => d.WorkorderId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_line_workorder_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_move_line_write_uid_fkey");

                //entity.HasMany(d => d.ConsumeLines).WithMany(p => p.ProduceLines)
                entity.HasMany<StockMoveLine>().WithMany()
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
                        });

                //entity.HasMany(d => d.ProduceLines).WithMany(p => p.ConsumeLines)
                entity.HasMany<StockMoveLine>().WithMany()
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
                        });
            });
        }
    }
}