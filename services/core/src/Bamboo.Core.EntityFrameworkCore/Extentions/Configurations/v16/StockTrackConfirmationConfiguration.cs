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
        public static void ConfigureStockTrackConfirmation(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockTrackConfirmation>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_track_confirmation_pkey");

            entity.ToTable("stock_track_confirmation");

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
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.StockTrackConfirmationCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_track_confirmation_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.StockTrackConfirmationWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_track_confirmation_write_uid_fkey");

            // entity.HasMany(d => d.ProductProduct).WithMany(p => p.StockTrackConfirmation)
            entity.HasMany(d => d.ProductProduct).WithMany()
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
                        j.IndexerProperty<Guid>("StockTrackConfirmationId").HasColumnName("stock_track_confirmation_id");
                        j.IndexerProperty<Guid>("ProductProductId").HasColumnName("product_product_id");
                    });

            // entity.HasMany(d => d.StockQuant).WithMany(p => p.StockTrackConfirmation)
            entity.HasMany(d => d.StockQuant).WithMany(p => p.StockTrackConfirmation)
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
                        j.IndexerProperty<Guid>("StockTrackConfirmationId").HasColumnName("stock_track_confirmation_id");
                        j.IndexerProperty<Guid>("StockQuantId").HasColumnName("stock_quant_id");
                    });
            });
        }
    }
}