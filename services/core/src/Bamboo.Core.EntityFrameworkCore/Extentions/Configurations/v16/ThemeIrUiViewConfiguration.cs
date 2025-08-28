using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureThemeIrUiView(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ThemeIrUiView>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("theme_ir_ui_view_pkey");

                        entity.ToTable("theme_ir_ui_view");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.Arch)
                            .HasColumnType("jsonb")
                            .HasColumnName("arch");
                        entity.Property(e => e.ArchFs).HasColumnName("arch_fs");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CustomizeShow).HasColumnName("customize_show");
                        entity.Property(e => e.InheritId).HasColumnName("inherit_id");
                        entity.Property(e => e.Key).HasColumnName("key");
                        entity.Property(e => e.Mode).HasColumnName("mode");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.Priority).HasColumnName("priority");
                        entity.Property(e => e.Type).HasColumnName("type");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ThemeIrUiViewCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("theme_ir_ui_view_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("theme_ir_ui_view_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ThemeIrUiViewWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("theme_ir_ui_view_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("theme_ir_ui_view_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}