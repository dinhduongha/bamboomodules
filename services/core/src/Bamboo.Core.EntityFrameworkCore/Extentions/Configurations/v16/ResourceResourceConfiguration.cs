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
        public static void ConfigureResourceResource(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ResourceResource>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("resource_resource_pkey");

            entity.ToTable("resource_resource");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CalendarId).HasColumnName("calendar_id");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.ResourceType).HasColumnName("resource_type");
            entity.Property(e => e.TimeEfficiency).HasColumnName("time_efficiency");
            entity.Property(e => e.Tz).HasColumnName("tz");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.Calendar).WithMany(p => p.ResourceResource)
                .HasForeignKey(d => d.CalendarId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("resource_resource_calendar_id_fkey");

            // entity.HasOne(d => d.Company).WithMany(p => p.ResourceResource)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("resource_resource_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.ResourceResourceCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("resource_resource_create_uid_fkey");

            // entity.HasOne(d => d.User).WithMany(p => p.ResourceResourceUser)
            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("resource_resource_user_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.ResourceResourceWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("resource_resource_write_uid_fkey");
            });
        }
    }
}
