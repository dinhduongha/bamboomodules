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
        public static void ConfigureSaleOrderTemplateLine(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<SaleOrderTemplateLine>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("sale_order_template_line_pkey");

            entity.ToTable("sale_order_template_line");

            entity.HasIndex(e => e.TenantId, "sale_order_template_line__company_id_index");

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.SaleOrderTemplateId, "sale_order_template_line__sale_order_template_id_index");

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
            entity.Property(e => e.DisplayType).HasColumnName("display_type");
            entity.Property(e => e.Name)
                .HasColumnType("jsonb")
                .HasColumnName("name");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductUomId).HasColumnName("product_uom_id");
            entity.Property(e => e.ProductUomQty).HasColumnName("product_uom_qty");
            entity.Property(e => e.SaleOrderTemplateId).HasColumnName("sale_order_template_id");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.Company).WithMany(p => p.SaleOrderTemplateLine)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("sale_order_template_line_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.SaleOrderTemplateLineCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("sale_order_template_line_create_uid_fkey");

            // entity.HasOne(d => d.Product).WithMany(p => p.SaleOrderTemplateLine)
            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("sale_order_template_line_product_id_fkey");

            // entity.HasOne(d => d.ProductUom).WithMany(p => p.SaleOrderTemplateLine)
            entity.HasOne(d => d.ProductUom).WithMany()
                .HasForeignKey(d => d.ProductUomId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("sale_order_template_line_product_uom_id_fkey");

            entity.HasOne(d => d.SaleOrderTemplate).WithMany(p => p.SaleOrderTemplateLine)
                .HasForeignKey(d => d.SaleOrderTemplateId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("sale_order_template_line_sale_order_template_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.SaleOrderTemplateLineWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("sale_order_template_line_write_uid_fkey");
            });
        }
    }
}
