using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureProductAttribute(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ProductAttribute>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("product_attribute_pkey");

                        entity.ToTable("product_attribute");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.CategoryId, "product_attribute__category_id_index");

                        entity.HasIndex(e => e.Sequence, "product_attribute__sequence_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.CategoryId).HasColumnName("category_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CreateVariant).HasColumnName("create_variant");
                        entity.Property(e => e.DisplayType).HasColumnName("display_type");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.Visibility).HasColumnName("visibility");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Category).WithMany(p => p.ProductAttribute)
                            .HasForeignKey(d => d.CategoryId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_attribute_category_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ProductAttributeCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_attribute_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_attribute_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ProductAttributeWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_attribute_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_attribute_write_uid_fkey");

                        // entity.HasMany(d => d.ProductTemplate).WithMany(p => p.ProductAttribute)
                        entity.HasMany(d => d.ProductTemplate).WithMany(p => p.ProductAttribute)
                            .UsingEntity<Dictionary<string, object>>(
                                "ProductAttributeProductTemplateRel",
                                r => r.HasOne<ProductTemplate>().WithMany()
                                    .HasForeignKey("ProductTemplateId")
                                    .HasConstraintName("product_attribute_product_template_rel_product_template_id_fkey"),
                                l => l.HasOne<ProductAttribute>().WithMany()
                                    .HasForeignKey("ProductAttributeId")
                                    .HasConstraintName("product_attribute_product_template_re_product_attribute_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ProductAttributeId", "ProductTemplateId").HasName("product_attribute_product_template_rel_pkey");
                                    j.ToTable("product_attribute_product_template_rel");
                                    j.HasIndex(new[] { "ProductTemplateId", "ProductAttributeId" }, "product_attribute_product_tem_product_template_id_product_a_idx");
                                    j.IndexerProperty<Guid>("ProductAttributeId").HasColumnName("product_attribute_id");
                                    j.IndexerProperty<Guid>("ProductTemplateId").HasColumnName("product_template_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}