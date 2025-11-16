using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureBlogTag(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<BlogTag>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("blog_tag_pkey");

                        entity.ToTable("blog_tag");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.CategoryId, "blog_tag__category_id_index");

                        entity.HasIndex(e => e.Name, "blog_tag_name_uniq").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CategoryId).HasColumnName("category_id");
                        entity.Property(e => e.Color).HasColumnName("color");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.SeoName)
                            .HasColumnType("jsonb")
                            .HasColumnName("seo_name");
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

                        entity.HasOne(d => d.Category).WithMany(p => p.BlogTag)
                            .HasForeignKey(d => d.CategoryId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("blog_tag_category_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.BlogTagCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("blog_tag_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("blog_tag_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.BlogTagWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("blog_tag_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("blog_tag_write_uid_fkey");

                        // entity.HasMany(d => d.BlogPost).WithMany(p => p.BlogTag)
                        entity.HasMany(d => d.BlogPost).WithMany(p => p.BlogTag)
                            .UsingEntity<Dictionary<string, object>>(
                                "BlogPostBlogTagRel",
                                r => r.HasOne<BlogPost>().WithMany()
                                    .HasForeignKey("BlogPostId")
                                    .HasConstraintName("blog_post_blog_tag_rel_blog_post_id_fkey"),
                                l => l.HasOne<BlogTag>().WithMany()
                                    .HasForeignKey("BlogTagId")
                                    .HasConstraintName("blog_post_blog_tag_rel_blog_tag_id_fkey"),
                                j =>
                                {
                                    j.HasKey("BlogTagId", "BlogPostId").HasName("blog_post_blog_tag_rel_pkey");
                                    j.ToTable("blog_post_blog_tag_rel");
                                    j.HasIndex(new[] { "BlogPostId", "BlogTagId" }, "blog_post_blog_tag_rel_blog_post_id_blog_tag_id_idx");
                                    j.IndexerProperty<Guid>("BlogTagId").HasColumnName("blog_tag_id");
                                    j.IndexerProperty<Guid>("BlogPostId").HasColumnName("blog_post_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}