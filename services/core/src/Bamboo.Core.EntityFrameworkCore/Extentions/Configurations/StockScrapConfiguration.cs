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
        public static void ConfigureStockScrap(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockScrap>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("stock_scrap_pkey");

                entity.ToTable("stock_scrap");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DateDone)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_done");
                entity.Property(e => e.LocationId).HasColumnName("location_id");
                entity.Property(e => e.LotId).HasColumnName("lot_id");
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                entity.Property(e => e.MoveId).HasColumnName("move_id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Origin).HasColumnName("origin");
                entity.Property(e => e.OwnerId).HasColumnName("owner_id");
                entity.Property(e => e.PackageId).HasColumnName("package_id");
                entity.Property(e => e.PickingId).HasColumnName("picking_id");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.ProductUomId).HasColumnName("product_uom_id");
                entity.Property(e => e.ProductionId).HasColumnName("production_id");
                entity.Property(e => e.ScrapLocationId).HasColumnName("scrap_location_id");
                entity.Property(e => e.ScrapQty).HasColumnName("scrap_qty");
                entity.Property(e => e.State).HasColumnName("state");
                entity.Property(e => e.WorkorderId).HasColumnName("workorder_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_scrap_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_scrap_create_uid_fkey");

                entity.HasOne(d => d.Location).WithMany(p => p.StockScrapLocations)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_scrap_location_id_fkey");

                entity.HasOne(d => d.Lot).WithMany(p => p.StockScraps)
                    .HasForeignKey(d => d.LotId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_scrap_lot_id_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.StockScraps)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_scrap_message_main_attachment_id_fkey");

                entity.HasOne(d => d.Move).WithMany(p => p.StockScraps)
                    .HasForeignKey(d => d.MoveId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_scrap_move_id_fkey");

                entity.HasOne(d => d.Owner).WithMany(p => p.StockScraps)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_scrap_owner_id_fkey");

                entity.HasOne(d => d.Package).WithMany(p => p.StockScraps)
                    .HasForeignKey(d => d.PackageId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_scrap_package_id_fkey");

                entity.HasOne(d => d.Picking).WithMany(p => p.StockScraps)
                    .HasForeignKey(d => d.PickingId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_scrap_picking_id_fkey");

                entity.HasOne(d => d.Product).WithMany(p => p.StockScraps)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_scrap_product_id_fkey");

                entity.HasOne(d => d.ProductUom).WithMany(p => p.StockScraps)
                    .HasForeignKey(d => d.ProductUomId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_scrap_product_uom_id_fkey");

                entity.HasOne(d => d.Production).WithMany(p => p.StockScraps)
                    .HasForeignKey(d => d.ProductionId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_scrap_production_id_fkey");

                entity.HasOne(d => d.ScrapLocation).WithMany(p => p.StockScrapScrapLocations)
                    .HasForeignKey(d => d.ScrapLocationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_scrap_scrap_location_id_fkey");

                entity.HasOne(d => d.Workorder).WithMany(p => p.StockScraps)
                    .HasForeignKey(d => d.WorkorderId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_scrap_workorder_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_scrap_write_uid_fkey");

                //entity.HasMany(d => d.StockScrapReasonTags).WithMany(p => p.StockScraps)
                entity.HasMany<StockScrapReasonTag>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "StockScrapStockScrapReasonTagRel",
                        r => r.HasOne<StockScrapReasonTag>().WithMany()
                            .HasForeignKey("StockScrapReasonTagId")
                            .HasConstraintName("stock_scrap_stock_scrap_reason_t_stock_scrap_reason_tag_id_fkey"),
                        l => l.HasOne<StockScrap>().WithMany()
                            .HasForeignKey("StockScrapId")
                            .HasConstraintName("stock_scrap_stock_scrap_reason_tag_rel_stock_scrap_id_fkey"),
                        j =>
                        {
                            j.HasKey("StockScrapId", "StockScrapReasonTagId").HasName("stock_scrap_stock_scrap_reason_tag_rel_pkey");
                            j.ToTable("stock_scrap_stock_scrap_reason_tag_rel");
                            j.HasIndex(new[] { "StockScrapReasonTagId", "StockScrapId" }, "stock_scrap_stock_scrap_reaso_stock_scrap_reason_tag_id_sto_idx");
                            j.IndexerProperty<Guid>("StockScrapId").HasColumnName("stock_scrap_id");
                            j.IndexerProperty<Guid>("StockScrapReasonTagId").HasColumnName("stock_scrap_reason_tag_id");
                        });
            });
        }
    }
}