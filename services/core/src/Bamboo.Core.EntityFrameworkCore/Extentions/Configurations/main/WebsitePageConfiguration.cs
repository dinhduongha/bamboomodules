using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureWebsitePage(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<WebsitePage>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("website_page_pkey");

                        entity.ToTable("website_page");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.IsPublished, "website_page__is_published_index");

                        entity.HasIndex(e => e.WebsiteId, "website_page__website_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DatePublish)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_publish");
                        entity.Property(e => e.FooterVisible).HasColumnName("footer_visible");
                        entity.Property(e => e.HeaderColor).HasColumnName("header_color");
                        entity.Property(e => e.HeaderOverlay).HasColumnName("header_overlay");
                        entity.Property(e => e.HeaderTextColor).HasColumnName("header_text_color");
                        entity.Property(e => e.HeaderVisible).HasColumnName("header_visible");
                        entity.Property(e => e.IsNewPageTemplate).HasColumnName("is_new_page_template");
                        entity.Property(e => e.IsPublished).HasColumnName("is_published");
                        entity.Property(e => e.ThemeTemplateId).HasColumnName("theme_template_id");
                        entity.Property(e => e.Url).HasColumnName("url");
                        entity.Property(e => e.ViewId).HasColumnName("view_id");
                        entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                        entity.Property(e => e.WebsiteIndexed).HasColumnName("website_indexed");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.WebsitePageCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("website_page_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_page_create_uid_fkey");

                        entity.HasOne(d => d.ThemeTemplate).WithMany(p => p.WebsitePage)
                            .HasForeignKey(d => d.ThemeTemplateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_page_theme_template_id_fkey");

                        entity.HasOne(d => d.View).WithMany(p => p.WebsitePage)
                            .HasForeignKey(d => d.ViewId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("website_page_view_id_fkey");

                        // entity.HasOne(d => d.Website).WithMany(p => p.WebsitePage) .HasForeignKey(d => d.WebsiteId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("website_page_website_id_fkey");
                        entity.HasOne(d => d.Website).WithMany()
                            .HasForeignKey(d => d.WebsiteId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("website_page_website_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.WebsitePageWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("website_page_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_page_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}