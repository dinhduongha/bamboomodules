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
        public static void ConfigureStockWarnInsufficientQtyUnbuild(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockWarnInsufficientQtyUnbuild>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_warn_insufficient_qty_unbuild_pkey");

            entity.ToTable("stock_warn_insufficient_qty_unbuild");

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
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductUomName).HasColumnName("product_uom_name");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UnbuildId).HasColumnName("unbuild_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.StockWarnInsufficientQtyUnbuildCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_warn_insufficient_qty_unbuild_create_uid_fkey");

            entity.HasOne(d => d.Location).WithMany(p => p.StockWarnInsufficientQtyUnbuild)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("stock_warn_insufficient_qty_unbuild_location_id_fkey");

            // entity.HasOne(d => d.Product).WithMany(p => p.StockWarnInsufficientQtyUnbuild)
            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("stock_warn_insufficient_qty_unbuild_product_id_fkey");

            entity.HasOne(d => d.Unbuild).WithMany(p => p.StockWarnInsufficientQtyUnbuild)
                .HasForeignKey(d => d.UnbuildId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_warn_insufficient_qty_unbuild_unbuild_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.StockWarnInsufficientQtyUnbuildWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_warn_insufficient_qty_unbuild_write_uid_fkey");
            });
        }
    }
}