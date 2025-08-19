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
        public static void ConfigureProductAttributeCustomValue(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ProductAttributeCustomValue>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("product_attribute_custom_value_pkey");

            entity.ToTable("product_attribute_custom_value");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => new { e.CustomProductTemplateAttributeValueId, e.SaleOrderLineId }, "product_attribute_custom_value_sol_custom_value_unique").IsUnique();

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
            entity.Property(e => e.CustomProductTemplateAttributeValueId).HasColumnName("custom_product_template_attribute_value_id");
            entity.Property(e => e.CustomValue).HasColumnName("custom_value");
            entity.Property(e => e.PosOrderLineId).HasColumnName("pos_order_line_id");
            entity.Property(e => e.SaleOrderLineId).HasColumnName("sale_order_line_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.ProductAttributeCustomValueCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("product_attribute_custom_value_create_uid_fkey");

            entity.HasOne(d => d.CustomProductTemplateAttributeValue).WithMany(p => p.ProductAttributeCustomValue)
                .HasForeignKey(d => d.CustomProductTemplateAttributeValueId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("product_attribute_custom_valu_custom_product_template_attr_fkey");

            entity.HasOne(d => d.PosOrderLine).WithMany(p => p.ProductAttributeCustomValue)
                .HasForeignKey(d => d.PosOrderLineId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("product_attribute_custom_value_pos_order_line_id_fkey");

            entity.HasOne(d => d.SaleOrderLine).WithMany(p => p.ProductAttributeCustomValue)
                .HasForeignKey(d => d.SaleOrderLineId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("product_attribute_custom_value_sale_order_line_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.ProductAttributeCustomValueWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("product_attribute_custom_value_write_uid_fkey");
            });
        }
    }
}
