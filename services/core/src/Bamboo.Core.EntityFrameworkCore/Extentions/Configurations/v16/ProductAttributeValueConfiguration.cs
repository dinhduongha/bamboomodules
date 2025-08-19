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
        public static void ConfigureProductAttributeValue(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ProductAttributeValue>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("product_attribute_value_pkey");

            entity.ToTable("product_attribute_value");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.AttributeId, "product_attribute_value__attribute_id_index");

            entity.HasIndex(e => e.Sequence, "product_attribute_value__sequence_index");

            entity.HasIndex(e => new { e.Name, e.AttributeId }, "product_attribute_value_value_company_uniq").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.AttributeId).HasColumnName("attribute_id");
            entity.Property(e => e.Color).HasColumnName("color");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.DefaultExtraPrice).HasColumnName("default_extra_price");
            entity.Property(e => e.HtmlColor).HasColumnName("html_color");
            entity.Property(e => e.IsCustom).HasColumnName("is_custom");
            entity.Property(e => e.Name)
                .HasColumnType("jsonb")
                .HasColumnName("name");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.Attribute).WithMany(p => p.ProductAttributeValue)
                .HasForeignKey(d => d.AttributeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("product_attribute_value_attribute_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.ProductAttributeValueCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("product_attribute_value_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.ProductAttributeValueWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("product_attribute_value_write_uid_fkey");

            // entity.HasMany(d => d.ProductTemplateAttributeLine).WithMany(p => p.ProductAttributeValue)
            entity.HasMany(d => d.ProductTemplateAttributeLine).WithMany(p => p.ProductAttributeValue)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductAttributeValueProductTemplateAttributeLineRel",
                    r => r.HasOne<ProductTemplateAttributeLine>().WithMany()
                        .HasForeignKey("ProductTemplateAttributeLineId")
                        .HasConstraintName("product_attribute_value_produ_product_template_attribute_l_fkey"),
                    l => l.HasOne<ProductAttributeValue>().WithMany()
                        .HasForeignKey("ProductAttributeValueId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("product_attribute_value_product_product_attribute_value_id_fkey"),
                    j =>
                    {
                        j.HasKey("ProductAttributeValueId", "ProductTemplateAttributeLineId").HasName("product_attribute_value_product_template_attribute_line_re_pkey");
                        j.ToTable("product_attribute_value_product_template_attribute_line_rel");
                        j.HasIndex(new[] { "ProductTemplateAttributeLineId", "ProductAttributeValueId" }, "product_attribute_value_produ_product_template_attribute_li_idx");
                        j.IndexerProperty<Guid>("ProductAttributeValueId").HasColumnName("product_attribute_value_id");
                        j.IndexerProperty<Guid>("ProductTemplateAttributeLineId").HasColumnName("product_template_attribute_line_id");
                    });
            });
        }
    }
}
