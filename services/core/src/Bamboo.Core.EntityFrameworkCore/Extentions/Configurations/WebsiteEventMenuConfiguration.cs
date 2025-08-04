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
        public static void ConfigureWebsiteEventMenu(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WebsiteEventMenu>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("website_event_menu_pkey");

                entity.ToTable("website_event_menu", tb => tb.HasComment("Website Event Menu"));

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasComment("Created on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId)
                    .HasComment("Created by")
                    .HasColumnName("create_uid");
                entity.Property(e => e.EventId)
                    .HasComment("Event")
                    .HasColumnName("event_id");
                entity.Property(e => e.MenuId)
                    .HasComment("Menu")
                    .HasColumnName("menu_id");
                entity.Property(e => e.MenuType)
                    .HasComment("Menu Type")
                    .HasColumnType("character varying")
                    .HasColumnName("menu_type");
                entity.Property(e => e.ViewId)
                    .HasComment("View")
                    .HasColumnName("view_id");
                entity.Property(e => e.LastModificationTime)
                    .HasComment("Last Updated on")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId)
                    .HasComment("Last Updated by")
                    .HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("website_event_menu_create_uid_fkey");

                entity.HasOne(d => d.Event).WithMany(p => p.WebsiteEventMenus)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("website_event_menu_event_id_fkey");

                entity.HasOne(d => d.Menu).WithMany()
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("website_event_menu_menu_id_fkey");

                entity.HasOne(d => d.View).WithMany(p => p.WebsiteEventMenus)
                    .HasForeignKey(d => d.ViewId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("website_event_menu_view_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("website_event_menu_write_uid_fkey");
            });
        }
    }
}