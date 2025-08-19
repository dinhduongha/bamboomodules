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
        public static void ConfigureStockChangeProductQty(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<StockChangeProductQty>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("stock_change_product_qty_pkey");

            entity.ToTable("stock_change_product_qty");

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
            entity.Property(e => e.NewQuantity).HasColumnName("new_quantity");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductTmplId).HasColumnName("product_tmpl_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.StockChangeProductQtyCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_change_product_qty_create_uid_fkey");

            // entity.HasOne(d => d.Product).WithMany(p => p.StockChangeProductQty)
            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("stock_change_product_qty_product_id_fkey");

            entity.HasOne(d => d.ProductTmpl).WithMany(p => p.StockChangeProductQty)
                .HasForeignKey(d => d.ProductTmplId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("stock_change_product_qty_product_tmpl_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.StockChangeProductQtyWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("stock_change_product_qty_write_uid_fkey");
            });
        }
    }
}