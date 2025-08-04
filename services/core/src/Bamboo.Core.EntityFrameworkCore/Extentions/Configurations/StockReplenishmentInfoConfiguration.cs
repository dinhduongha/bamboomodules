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
        public static void ConfigureStockReplenishmentInfo(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockReplenishmentInfo>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("stock_replenishment_info_pkey");

                entity.ToTable("stock_replenishment_info");

                entity.HasIndex(e => e.TenantId, "stock_replenishment_info_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.OrderpointId).HasColumnName("orderpoint_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_replenishment_info_create_uid_fkey");

                entity.HasOne(d => d.Orderpoint).WithMany(p => p.StockReplenishmentInfos)
                    .HasForeignKey(d => d.OrderpointId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_replenishment_info_orderpoint_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_replenishment_info_write_uid_fkey");

                //entity.HasMany(d => d.ProductSupplierinfos).WithMany(p => p.StockReplenishmentInfos)
                entity.HasMany<ProductSupplierinfo>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductSupplierinfoStockReplenishmentInfoRel",
                        r => r.HasOne<ProductSupplierinfo>().WithMany()
                            .HasForeignKey("ProductSupplierinfoId")
                            .HasConstraintName("product_supplierinfo_stock_repleni_product_supplierinfo_id_fkey"),
                        l => l.HasOne<StockReplenishmentInfo>().WithMany()
                            .HasForeignKey("StockReplenishmentInfoId")
                            .HasConstraintName("product_supplierinfo_stock_rep_stock_replenishment_info_id_fkey"),
                        j =>
                        {
                            j.HasKey("StockReplenishmentInfoId", "ProductSupplierinfoId").HasName("product_supplierinfo_stock_replenishment_info_rel_pkey");
                            j.ToTable("product_supplierinfo_stock_replenishment_info_rel");
                            j.HasIndex(new[] { "ProductSupplierinfoId", "StockReplenishmentInfoId" }, "product_supplierinfo_stock_re_product_supplierinfo_id_stock_idx");
                        });
            });
        }
    }
}