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
        public static void ConfigureCalendarPopoverDeleteWizard(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<CalendarPopoverDeleteWizard>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("calendar_popover_delete_wizard_pkey");

            entity.ToTable("calendar_popover_delete_wizard");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

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
            entity.Property(e => e.Delete).HasColumnName("delete");
            entity.Property(e => e.Record).HasColumnName("record");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.CalendarPopoverDeleteWizardCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("calendar_popover_delete_wizard_create_uid_fkey");

            entity.HasOne(d => d.RecordNavigation).WithMany(p => p.CalendarPopoverDeleteWizard)
                .HasForeignKey(d => d.Record)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("calendar_popover_delete_wizard_record_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.CalendarPopoverDeleteWizardWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("calendar_popover_delete_wizard_write_uid_fkey");
            });
        }
    }
}