using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.ToTable("website_event_menu");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

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
                        entity.Property(e => e.EventId).HasColumnName("event_id");
                        entity.Property(e => e.MenuId).HasColumnName("menu_id");
                        entity.Property(e => e.MenuType).HasColumnName("menu_type");
                        entity.Property(e => e.ViewId).HasColumnName("view_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.WebsiteEventMenuCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("website_event_menu_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_event_menu_create_uid_fkey");

                        entity.HasOne(d => d.Event).WithMany(p => p.WebsiteEventMenu)
                            .HasForeignKey(d => d.EventId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("website_event_menu_event_id_fkey");

                        entity.HasOne(d => d.Menu).WithMany(p => p.WebsiteEventMenu)
                            .HasForeignKey(d => d.MenuId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("website_event_menu_menu_id_fkey");

                        entity.HasOne(d => d.View).WithMany(p => p.WebsiteEventMenu)
                            .HasForeignKey(d => d.ViewId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("website_event_menu_view_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.WebsiteEventMenuWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("website_event_menu_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_event_menu_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}