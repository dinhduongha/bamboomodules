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
        public static void ConfigureProductTemplateAttributeExclusion(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductTemplateAttributeExclusion>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("product_template_attribute_exclusion_pkey");

                entity.ToTable("product_template_attribute_exclusion");

                entity.HasIndex(e => e.TenantId, "product_template_attribute_exclusion_company_id_index");

                entity.HasIndex(e => e.ProductTemplateAttributeValueId, "product_template_attribute_exclusion_product_template_attribute");

                entity.HasIndex(e => e.ProductTmplId, "product_template_attribute_exclusion_product_tmpl_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.ProductTemplateAttributeValueId).HasColumnName("product_template_attribute_value_id");
                entity.Property(e => e.ProductTmplId).HasColumnName("product_tmpl_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_template_attribute_exclusion_create_uid_fkey");

                entity.HasOne(d => d.ProductTemplateAttributeValue).WithMany(p => p.ProductTemplateAttributeExclusionsNavigation)
                    .HasForeignKey(d => d.ProductTemplateAttributeValueId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("product_template_attribute_ex_product_template_attribute_v_fkey");

                entity.HasOne(d => d.ProductTmpl).WithMany(p => p.ProductTemplateAttributeExclusions)
                    .HasForeignKey(d => d.ProductTmplId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("product_template_attribute_exclusion_product_tmpl_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_template_attribute_exclusion_write_uid_fkey");

                //entity.HasMany(d => d.ProductTemplateAttributeValues).WithMany(p => p.ProductTemplateAttributeExclusions)
                entity.HasMany<ProductTemplateAttributeValue>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductAttrExclusionValueIdsRel",
                        r => r.HasOne<ProductTemplateAttributeValue>().WithMany()
                            .HasForeignKey("ProductTemplateAttributeValueId")
                            .HasConstraintName("product_attr_exclusion_value__product_template_attribute_v_fkey"),
                        l => l.HasOne<ProductTemplateAttributeExclusion>().WithMany()
                            .HasForeignKey("ProductTemplateAttributeExclusionId")
                            .HasConstraintName("product_attr_exclusion_value__product_template_attribute_e_fkey"),
                        j =>
                        {
                            j.HasKey("ProductTemplateAttributeExclusionId", "ProductTemplateAttributeValueId").HasName("product_attr_exclusion_value_ids_rel_pkey");
                            j.ToTable("product_attr_exclusion_value_ids_rel");
                            j.HasIndex(new[] { "ProductTemplateAttributeValueId", "ProductTemplateAttributeExclusionId" }, "product_attr_exclusion_value__product_template_attribute_va_idx");
                        });
            });
        }
    }
}