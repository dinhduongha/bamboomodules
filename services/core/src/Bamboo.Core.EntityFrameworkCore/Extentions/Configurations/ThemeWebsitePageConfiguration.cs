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
        public static void ConfigureThemeWebsitePage(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ThemeWebsitePage>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("theme_website_page_pkey");

                entity.ToTable("theme_website_page");

                //entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.FooterVisible).HasColumnName("footer_visible");
                entity.Property(e => e.HeaderColor).HasColumnName("header_color");
                entity.Property(e => e.HeaderOverlay).HasColumnName("header_overlay");
                entity.Property(e => e.HeaderVisible).HasColumnName("header_visible");
                entity.Property(e => e.IsPublished).HasColumnName("is_published");
                entity.Property(e => e.Url).HasColumnName("url");
                entity.Property(e => e.ViewId).HasColumnName("view_id");
                entity.Property(e => e.WebsiteIndexed).HasColumnName("website_indexed");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("theme_website_page_create_uid_fkey");

                entity.HasOne(d => d.View).WithMany(p => p.ThemeWebsitePages)
                    .HasForeignKey(d => d.ViewId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("theme_website_page_view_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("theme_website_page_write_uid_fkey");
            });
        }
    }
}