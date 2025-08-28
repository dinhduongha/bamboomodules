using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureProductTemplateAttributeValue(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ProductTemplateAttributeValue>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("product_template_attribute_value_pkey");

                        entity.ToTable("product_template_attribute_value");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.AttributeId, "product_template_attribute_value__attribute_id_index");

                        entity.HasIndex(e => e.AttributeLineId, "product_template_attribute_value__attribute_line_id_index");

                        entity.HasIndex(e => e.ProductAttributeValueId, "product_template_attribute_value__product_attribute_va_63041d9e");

                        entity.HasIndex(e => e.ProductTmplId, "product_template_attribute_value__product_tmpl_id_index");

                        entity.HasIndex(e => new { e.AttributeLineId, e.ProductAttributeValueId }, "product_template_attribute_value_attribute_value_unique").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AttributeId).HasColumnName("attribute_id");
                        entity.Property(e => e.AttributeLineId).HasColumnName("attribute_line_id");
                        entity.Property(e => e.Color).HasColumnName("color");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.PriceExtra).HasColumnName("price_extra");
                        entity.Property(e => e.ProductAttributeValueId).HasColumnName("product_attribute_value_id");
                        entity.Property(e => e.ProductTmplId).HasColumnName("product_tmpl_id");
                        entity.Property(e => e.PtavActive).HasColumnName("ptav_active");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Attribute).WithMany(p => p.ProductTemplateAttributeValue)
                            .HasForeignKey(d => d.AttributeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_template_attribute_value_attribute_id_fkey");

                        entity.HasOne(d => d.AttributeLine).WithMany(p => p.ProductTemplateAttributeValue)
                            .HasForeignKey(d => d.AttributeLineId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("product_template_attribute_value_attribute_line_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ProductTemplateAttributeValueCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_template_attribute_value_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_template_attribute_value_create_uid_fkey");

                        entity.HasOne(d => d.ProductAttributeValue).WithMany(p => p.ProductTemplateAttributeValue)
                            .HasForeignKey(d => d.ProductAttributeValueId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("product_template_attribute_valu_product_attribute_value_id_fkey");

                        entity.HasOne(d => d.ProductTmpl).WithMany(p => p.ProductTemplateAttributeValue)
                            .HasForeignKey(d => d.ProductTmplId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_template_attribute_value_product_tmpl_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ProductTemplateAttributeValueWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_template_attribute_value_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_template_attribute_value_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}