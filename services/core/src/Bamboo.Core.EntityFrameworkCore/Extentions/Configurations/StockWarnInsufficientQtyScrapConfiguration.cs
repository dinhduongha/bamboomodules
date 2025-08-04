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
        public static void ConfigureStockWarnInsufficientQtyScrap(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockWarnInsufficientQtyScrap>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("stock_warn_insufficient_qty_scrap_pkey");

                entity.ToTable("stock_warn_insufficient_qty_scrap");

                entity.HasIndex(e => e.TenantId, "stock_warn_insufficient_qty_scrap_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.LocationId).HasColumnName("location_id");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.ProductUomName).HasColumnName("product_uom_name");
                entity.Property(e => e.Quantity).HasColumnName("quantity");
                entity.Property(e => e.ScrapId).HasColumnName("scrap_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_warn_insufficient_qty_scrap_create_uid_fkey");

                entity.HasOne(d => d.Location).WithMany(p => p.StockWarnInsufficientQtyScraps)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("stock_warn_insufficient_qty_scrap_location_id_fkey");

                entity.HasOne(d => d.Product).WithMany(p => p.StockWarnInsufficientQtyScraps)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("stock_warn_insufficient_qty_scrap_product_id_fkey");

                entity.HasOne(d => d.Scrap).WithMany(p => p.StockWarnInsufficientQtyScraps)
                    .HasForeignKey(d => d.ScrapId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_warn_insufficient_qty_scrap_scrap_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_warn_insufficient_qty_scrap_write_uid_fkey");
            });
        }
    }
}