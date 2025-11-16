using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureForumTag(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ForumTag>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("forum_tag_pkey");

                        entity.ToTable("forum_tag");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.ForumId, "forum_tag__forum_id_index");

                        entity.HasIndex(e => new { e.Name, e.ForumId }, "forum_tag_name_uniq").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Color).HasColumnName("color");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.ForumId).HasColumnName("forum_id");
                        entity.Property(e => e.IsSeoOptimized).HasColumnName("is_seo_optimized");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.PostsCount).HasColumnName("posts_count");
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

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ForumTagCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("forum_tag_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("forum_tag_create_uid_fkey");

                        entity.HasOne(d => d.Forum).WithMany(p => p.ForumTag)
                            .HasForeignKey(d => d.ForumId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("forum_tag_forum_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ForumTagWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("forum_tag_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("forum_tag_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}