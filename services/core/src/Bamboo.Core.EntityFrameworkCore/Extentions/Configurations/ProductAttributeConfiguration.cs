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
        public static void ConfigureProductAttribute(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductAttribute>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("product_attribute_pkey");

                entity.ToTable("product_attribute");

                entity.HasIndex(e => e.TenantId, "product_attribute_company_id_index");

                entity.HasIndex(e => e.Sequence, "product_attribute_sequence_index");

                //entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.CreateVariant).HasColumnName("create_variant");
                entity.Property(e => e.DisplayType).HasColumnName("display_type");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.Visibility).HasColumnName("visibility");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_attribute_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("product_attribute_write_uid_fkey");

                //entity.HasMany(d => d.ProductTemplates).WithMany(p => p.ProductAttributes)
                entity.HasMany<ProductTemplate>().WithMany()
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
                        });
            });
        }
    }
}