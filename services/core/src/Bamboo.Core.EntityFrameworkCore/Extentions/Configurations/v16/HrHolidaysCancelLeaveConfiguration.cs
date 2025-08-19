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
        public static void ConfigureHrHolidaysCancelLeave(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrHolidaysCancelLeave>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_holidays_cancel_leave_pkey");

            entity.ToTable("hr_holidays_cancel_leave");

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
            entity.Property(e => e.LeaveId).HasColumnName("leave_id");
            entity.Property(e => e.Reason).HasColumnName("reason");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.HrHolidaysCancelLeaveCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_holidays_cancel_leave_create_uid_fkey");

            entity.HasOne(d => d.Leave).WithMany(p => p.HrHolidaysCancelLeave)
                .HasForeignKey(d => d.LeaveId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("hr_holidays_cancel_leave_leave_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.HrHolidaysCancelLeaveWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("hr_holidays_cancel_leave_write_uid_fkey");
            });
        }
    }
}