using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureProductPublicCategory(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ProductPublicCategory>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("product_public_category_pkey");

                        entity.ToTable("product_public_category");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.ParentId, "product_public_category__parent_id_index");

                        entity.HasIndex(e => e.ParentPath, "product_public_category__parent_path_index");

                        entity.HasIndex(e => e.Sequence, "product_public_category__sequence_index");

                        entity.HasIndex(e => e.WebsiteId, "product_public_category__website_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AlignCategoryContent).HasColumnName("align_category_content");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.IsSeoOptimized).HasColumnName("is_seo_optimized");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.ParentId).HasColumnName("parent_id");
                        entity.Property(e => e.ParentPath).HasColumnName("parent_path");
                        entity.Property(e => e.SeoName)
                            .HasColumnType("jsonb")
                            .HasColumnName("seo_name");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.ShowCategoryDescription).HasColumnName("show_category_description");
                        entity.Property(e => e.ShowCategoryTitle).HasColumnName("show_category_title");
                        entity.Property(e => e.WebsiteDescription)
                            .HasColumnType("jsonb")
                            .HasColumnName("website_description");
                        entity.Property(e => e.WebsiteFooter)
                            .HasColumnType("jsonb")
                            .HasColumnName("website_footer");
                        entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                        entity.Property(e => e.WebsiteMetaDescription)
                            .HasColumnType("jsonb")
                            .HasColumnName("website_meta_description");
                        entity.Property(e => e.WebsiteMetaKeywords)
                            .HasColumnType("jsonb")
                            .HasColumnName("website_meta_keywords");
                        entity.Property(e => e.WebsiteMetaOgImg).HasColumnName("website_meta_og_img");
                        entity.Property(e => e.WebsiteMetaTitle)
                            .HasColumnType("jsonb")
                            .HasColumnName("website_meta_title");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ProductPublicCategoryCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_public_category_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_public_category_create_uid_fkey");

                        entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                            .HasForeignKey(d => d.ParentId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("product_public_category_parent_id_fkey");

                        // entity.HasOne(d => d.Website).WithMany(p => p.ProductPublicCategory) .HasForeignKey(d => d.WebsiteId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("product_public_category_website_id_fkey");
                        entity.HasOne(d => d.Website).WithMany()
                            .HasForeignKey(d => d.WebsiteId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("product_public_category_website_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ProductPublicCategoryWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_public_category_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_public_category_write_uid_fkey");

                        // entity.HasMany(d => d.ProductTemplate).WithMany(p => p.ProductPublicCategory)
                        entity.HasMany(d => d.ProductTemplate).WithMany(p => p.ProductPublicCategory)
                            .UsingEntity<Dictionary<string, object>>(
                                "ProductPublicCategoryProductTemplateRel",
                                r => r.HasOne<ProductTemplate>().WithMany()
                                    .HasForeignKey("ProductTemplateId")
                                    .HasConstraintName("product_public_category_product_templa_product_template_id_fkey"),
                                l => l.HasOne<ProductPublicCategory>().WithMany()
                                    .HasForeignKey("ProductPublicCategoryId")
                                    .HasConstraintName("product_public_category_product_product_public_category_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ProductPublicCategoryId", "ProductTemplateId").HasName("product_public_category_product_template_rel_pkey");
                                    j.ToTable("product_public_category_product_template_rel");
                                    j.HasIndex(new[] { "ProductTemplateId", "ProductPublicCategoryId" }, "product_public_category_produ_product_template_id_product_p_idx");
                                    j.IndexerProperty<Guid>("ProductPublicCategoryId").HasColumnName("product_public_category_id");
                                    j.IndexerProperty<Guid>("ProductTemplateId").HasColumnName("product_template_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}