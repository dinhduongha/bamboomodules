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
        public static void ConfigureStockTrackConfirmation(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockTrackConfirmation>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("stock_track_confirmation_pkey");

                entity.ToTable("stock_track_confirmation");

                entity.HasIndex(e => e.TenantId, "stock_track_confirmation_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_track_confirmation_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_track_confirmation_write_uid_fkey");

                //entity.HasMany(d => d.ProductProducts).WithMany(p => p.StockTrackConfirmations)
                entity.HasMany<ProductProduct>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductProductStockTrackConfirmationRel",
                        r => r.HasOne<ProductProduct>().WithMany()
                            .HasForeignKey("ProductProductId")
                            .HasConstraintName("product_product_stock_track_confirmatio_product_product_id_fkey"),
                        l => l.HasOne<StockTrackConfirmation>().WithMany()
                            .HasForeignKey("StockTrackConfirmationId")
                            .HasConstraintName("product_product_stock_track_co_stock_track_confirmation_id_fkey"),
                        j =>
                        {
                            j.HasKey("StockTrackConfirmationId", "ProductProductId").HasName("product_product_stock_track_confirmation_rel_pkey");
                            j.ToTable("product_product_stock_track_confirmation_rel");
                            j.HasIndex(new[] { "ProductProductId", "StockTrackConfirmationId" }, "product_product_stock_track_c_product_product_id_stock_trac_idx");
                        });

                //entity.HasMany(d => d.StockQuants).WithMany(p => p.StockTrackConfirmations)
                entity.HasMany<StockQuant>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "StockQuantStockTrackConfirmationRel",
                        r => r.HasOne<StockQuant>().WithMany()
                            .HasForeignKey("StockQuantId")
                            .HasConstraintName("stock_quant_stock_track_confirmation_rel_stock_quant_id_fkey"),
                        l => l.HasOne<StockTrackConfirmation>().WithMany()
                            .HasForeignKey("StockTrackConfirmationId")
                            .HasConstraintName("stock_quant_stock_track_confir_stock_track_confirmation_id_fkey"),
                        j =>
                        {
                            j.HasKey("StockTrackConfirmationId", "StockQuantId").HasName("stock_quant_stock_track_confirmation_rel_pkey");
                            j.ToTable("stock_quant_stock_track_confirmation_rel");
                            j.HasIndex(new[] { "StockQuantId", "StockTrackConfirmationId" }, "stock_quant_stock_track_confi_stock_quant_id_stock_track_co_idx");
                        });
            });
        }
    }
}