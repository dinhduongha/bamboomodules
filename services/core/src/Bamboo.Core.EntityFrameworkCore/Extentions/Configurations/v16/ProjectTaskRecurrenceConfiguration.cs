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
        public static void ConfigureProjectTaskRecurrence(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ProjectTaskRecurrence>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("project_task_recurrence_pkey");

            entity.ToTable("project_task_recurrence");

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
            entity.Property(e => e.Fri).HasColumnName("fri");
            entity.Property(e => e.Mon).HasColumnName("mon");
            entity.Property(e => e.NextRecurrenceDate).HasColumnName("next_recurrence_date");
            entity.Property(e => e.RecurrenceLeft).HasColumnName("recurrence_left");
            entity.Property(e => e.RepeatDay).HasColumnName("repeat_day");
            entity.Property(e => e.RepeatInterval).HasColumnName("repeat_interval");
            entity.Property(e => e.RepeatMonth).HasColumnName("repeat_month");
            entity.Property(e => e.RepeatNumber).HasColumnName("repeat_number");
            entity.Property(e => e.RepeatOnMonth).HasColumnName("repeat_on_month");
            entity.Property(e => e.RepeatOnYear).HasColumnName("repeat_on_year");
            entity.Property(e => e.RepeatType).HasColumnName("repeat_type");
            entity.Property(e => e.RepeatUnit).HasColumnName("repeat_unit");
            entity.Property(e => e.RepeatUntil).HasColumnName("repeat_until");
            entity.Property(e => e.RepeatWeek).HasColumnName("repeat_week");
            entity.Property(e => e.RepeatWeekday).HasColumnName("repeat_weekday");
            entity.Property(e => e.Sat).HasColumnName("sat");
            entity.Property(e => e.Sun).HasColumnName("sun");
            entity.Property(e => e.Thu).HasColumnName("thu");
            entity.Property(e => e.Tue).HasColumnName("tue");
            entity.Property(e => e.Wed).HasColumnName("wed");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.ProjectTaskRecurrenceCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("project_task_recurrence_create_uid_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.ProjectTaskRecurrenceWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("project_task_recurrence_write_uid_fkey");
            });
        }
    }
}