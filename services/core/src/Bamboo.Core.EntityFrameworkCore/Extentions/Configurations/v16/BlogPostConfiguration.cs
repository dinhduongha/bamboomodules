using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureBlogPost(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<BlogPost>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("blog_post_pkey");

                        entity.ToTable("blog_post");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.AuthorId, "blog_post__author_id_index").HasFilter("(author_id IS NOT NULL)");

                        entity.HasIndex(e => e.IsPublished, "blog_post__is_published_index");

                        entity.HasIndex(e => e.WebsiteId, "blog_post__website_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.AuthorId).HasColumnName("author_id");
                        entity.Property(e => e.AuthorName).HasColumnName("author_name");
                        entity.Property(e => e.BlogId).HasColumnName("blog_id");
                        entity.Property(e => e.Content)
                            .HasColumnType("jsonb")
                            .HasColumnName("content");
                        entity.Property(e => e.CoverProperties).HasColumnName("cover_properties");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.IsPublished).HasColumnName("is_published");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.PostDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("post_date");
                        entity.Property(e => e.PublishedDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("published_date");
                        entity.Property(e => e.SeoName)
                            .HasColumnType("jsonb")
                            .HasColumnName("seo_name");
                        entity.Property(e => e.Subtitle)
                            .HasColumnType("jsonb")
                            .HasColumnName("subtitle");
                        entity.Property(e => e.TeaserManual)
                            .HasColumnType("jsonb")
                            .HasColumnName("teaser_manual");
                        entity.Property(e => e.Visits).HasColumnName("visits");
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

                        // entity.HasOne(d => d.Author).WithMany(p => p.BlogPost) .HasForeignKey(d => d.AuthorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("blog_post_author_id_fkey");
                        entity.HasOne(d => d.Author).WithMany()
                            .HasForeignKey(d => d.AuthorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("blog_post_author_id_fkey");

                        entity.HasOne(d => d.Blog).WithMany(p => p.BlogPost)
                            .HasForeignKey(d => d.BlogId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("blog_post_blog_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.BlogPostCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("blog_post_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("blog_post_create_uid_fkey");

                        // entity.HasOne(d => d.Website).WithMany(p => p.BlogPost) .HasForeignKey(d => d.WebsiteId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("blog_post_website_id_fkey");
                        entity.HasOne(d => d.Website).WithMany()
                            .HasForeignKey(d => d.WebsiteId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("blog_post_website_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.BlogPostWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("blog_post_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("blog_post_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}