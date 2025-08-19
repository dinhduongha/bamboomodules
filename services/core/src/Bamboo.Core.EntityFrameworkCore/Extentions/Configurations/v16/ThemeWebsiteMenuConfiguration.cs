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
        public static void ConfigureThemeWebsiteMenu(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ThemeWebsiteMenu>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("theme_website_menu_pkey");

            entity.ToTable("theme_website_menu");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.ParentId, "theme_website_menu__parent_id_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.MegaMenuClasses).HasColumnName("mega_menu_classes");
            entity.Property(e => e.MegaMenuContent).HasColumnName("mega_menu_content");
            entity.Property(e => e.Name)
                .HasColumnType("jsonb")
                .HasColumnName("name");
            entity.Property(e => e.NewWindow).HasColumnName("new_window");
            entity.Property(e => e.PageId).HasColumnName("page_id");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.Url).HasColumnName("url");
            entity.Property(e => e.UseMainMenuAsParent).HasColumnName("use_main_menu_as_parent");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.ThemeWebsiteMenuCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("theme_website_menu_create_uid_fkey");

            entity.HasOne(d => d.Page).WithMany(p => p.ThemeWebsiteMenu)
                .HasForeignKey(d => d.PageId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("theme_website_menu_page_id_fkey");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("theme_website_menu_parent_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.ThemeWebsiteMenuWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("theme_website_menu_write_uid_fkey");
            });
        }
    }
}
