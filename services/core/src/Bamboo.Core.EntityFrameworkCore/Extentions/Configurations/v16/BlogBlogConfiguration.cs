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
        public static void ConfigureBlogBlog(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<BlogBlog>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("blog_blog_pkey");

            entity.ToTable("blog_blog");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.WebsiteId, "blog_blog_website_id_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Content)
                .HasColumnType("jsonb")
                .HasColumnName("content");
            entity.Property(e => e.CoverProperties).HasColumnName("cover_properties");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
            entity.Property(e => e.Name)
                .HasColumnType("jsonb")
                .HasColumnName("name");
            entity.Property(e => e.SeoName)
                .HasColumnType("jsonb")
                .HasColumnName("seo_name");
            entity.Property(e => e.Subtitle)
                .HasColumnType("jsonb")
                .HasColumnName("subtitle");
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

            // entity.HasOne(d => d.CreateU).WithMany(p => p.BlogBlogCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("blog_blog_create_uid_fkey");

            // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.BlogBlog)
            entity.HasOne(d => d.MessageMainAttachment).WithMany()
                .HasForeignKey(d => d.MessageMainAttachmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("blog_blog_message_main_attachment_id_fkey");

            // entity.HasOne(d => d.Website).WithMany(p => p.BlogBlog)
            entity.HasOne(d => d.Website).WithMany()
                .HasForeignKey(d => d.WebsiteId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("blog_blog_website_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.BlogBlogWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("blog_blog_write_uid_fkey");
            });
        }
    }
}