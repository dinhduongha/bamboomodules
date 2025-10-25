using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureProductTemplateAttributeLine(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ProductTemplateAttributeLine>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("product_template_attribute_line_pkey");

                        entity.ToTable("product_template_attribute_line");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.AttributeId, "product_template_attribute_line__attribute_id_index");

                        entity.HasIndex(e => e.ProductTmplId, "product_template_attribute_line__product_tmpl_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.AttributeId).HasColumnName("attribute_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.ProductTmplId).HasColumnName("product_tmpl_id");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.ValueCount).HasColumnName("value_count");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Attribute).WithMany(p => p.ProductTemplateAttributeLine)
                            .HasForeignKey(d => d.AttributeId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("product_template_attribute_line_attribute_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ProductTemplateAttributeLineCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_template_attribute_line_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_template_attribute_line_create_uid_fkey");

                        entity.HasOne(d => d.ProductTmpl).WithMany(p => p.ProductTemplateAttributeLine)
                            .HasForeignKey(d => d.ProductTmplId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("product_template_attribute_line_product_tmpl_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ProductTemplateAttributeLineWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_template_attribute_line_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_template_attribute_line_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}