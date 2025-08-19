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
        public static void ConfigureCalendarFilters(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<CalendarFilters>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("calendar_filters_pkey");

            entity.ToTable("calendar_filters");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.PartnerId, "calendar_filters_partner_id_index");

            entity.HasIndex(e => e.UserId, "calendar_filters_user_id_index");

            entity.HasIndex(e => new { e.UserId, e.PartnerId }, "calendar_filters_user_id_partner_id_unique").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.PartnerChecked).HasColumnName("partner_checked");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.CalendarFiltersCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("calendar_filters_create_uid_fkey");

            // entity.HasOne(d => d.Partner).WithMany(p => p.CalendarFilters)
            entity.HasOne(d => d.Partner).WithMany()
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("calendar_filters_partner_id_fkey");

            // entity.HasOne(d => d.User).WithMany(p => p.CalendarFiltersUser)
            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("calendar_filters_user_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.CalendarFiltersWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("calendar_filters_write_uid_fkey");
            });
        }
    }
}
